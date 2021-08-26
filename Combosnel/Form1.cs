using Nefarius.ViGEm.Client;
using Nefarius.ViGEm.Client.Targets;
using Nefarius.ViGEm.Client.Targets.Xbox360;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Combosnel
{
    public partial class Form1 : Form
    {
        private bool _isConnected;
        private ViGEmClient _controllerClient;
        private IXbox360Controller _controller;

        private System.Timers.Timer _shieldTimer;
        private System.Timers.Timer _sdiTimer;
        private System.Timers.Timer _diTimer;

        private Direction _currentDIAngle;
        private Direction _currentSDIAngle;
        private ShieldType _currentShieldType;
        private Button _currentButton;

        private bool _shieldStatus;
        private int _currentSDIIDX = 0;
        private int _sdiDelta = 1;

        public Form1()
        {
            InitializeComponent();

            // Set the data sources for each dropdown to an Enum so we can easily get enum values later
            cmbShieldType.DataSource = Enum.GetValues(typeof(ShieldType));
            cmbDIDirection.DataSource = Enum.GetValues(typeof(Direction));
            cmbSDIDirection.DataSource = Enum.GetValues(typeof(Direction));
            cmbButton.DataSource = Enum.GetValues(typeof(Button));
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!_isConnected)
            {
                // Enable some of the controls
                grbCPUOptions.Enabled = true;
                chbEnableDI.Enabled = true;
                chbShieldHold.Enabled = true;
                chbEnableSDI.Enabled = true;

                btnPressSelected.Enabled = true;
                cmbButton.Enabled = true;

                // Create a new ViGEm Client
                _controllerClient = new ViGEmClient();

                // Create the controller and connect it.
                _controller = _controllerClient.CreateXbox360Controller();
                _controller.AutoSubmitReport = false;
                _controller.Connect();

                // Update the UI 
                btnConnect.Text = "Disconnect Controller";

                // Set the status to connected.
                _isConnected = true;
            }

            else
            {
                // Update the button text.
                btnConnect.Text = "Connect Controller";

                // Disable the group box, with all the controls inside.
                grbCPUOptions.Enabled = false;

                // Disconnect the controller.
                _controller.Disconnect();

                // Set the status as disconnected.
                _isConnected = false;
            }
        }

        private void btnPressSelected_Click(object sender, EventArgs e)
        {
            // We need to wait for a certain amount of time before releasing the button.
            // Wait for 24ms before releasing it.
            var sw = Stopwatch.StartNew();

            if (_currentButton == Button.LeftTrigger)
            {
                _controller.SetSliderValue(Xbox360Slider.LeftTrigger, 255);
                _controller.SubmitReport();

                while (sw.ElapsedTicks < 240000) { }

                _controller.SetSliderValue(Xbox360Slider.LeftTrigger, 0);
                _controller.SubmitReport();
            }

            else if (_currentButton == Button.RightTrigger)
            {
                _controller.SetSliderValue(Xbox360Slider.RightTrigger, 255);
                _controller.SubmitReport();

                while (sw.ElapsedTicks < 240000) { }

                _controller.SetSliderValue(Xbox360Slider.RightTrigger, 0);
                _controller.SubmitReport();
            }

            else if (_currentButton == Button.StickDown)
            {
                _controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)Directions.angDown.X);
                _controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)Directions.angDown.Y);
                _controller.SubmitReport();

                while (sw.ElapsedTicks < 240000) { }

                _controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)Directions.angNone.X);
                _controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)Directions.angNone.Y);
                _controller.SubmitReport();
            }

            else if (_currentButton == Button.StickUp)
            {
                _controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)Directions.angUp.X);
                _controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)Directions.angUp.Y);
                _controller.SubmitReport();

                while (sw.ElapsedTicks < 240000) { }

                _controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)Directions.angNone.X);
                _controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)Directions.angNone.Y);
                _controller.SubmitReport();                      
            }                                                    
                                                                 
            else if (_currentButton == Button.StickRight)        
            {                                                    
                _controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)Directions.angForward.X);
                _controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)Directions.angForward.Y);
                _controller.SubmitReport();                     
                                                                
                while (sw.ElapsedTicks < 240000) { }            
                                                                
                _controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)Directions.angNone.X);
                _controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)Directions.angNone.Y);
                _controller.SubmitReport();                    
            }                                                  
                                                               
            else if (_currentButton == Button.StickLeft)       
            {                                                  
                _controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)Directions.angBackwards.X);
                _controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)Directions.angBackwards.Y);
                _controller.SubmitReport();                     
                                                                
                while (sw.ElapsedTicks < 240000) { }            
                                                                
                _controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)Directions.angNone.X);
                _controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)Directions.angNone.Y);
                _controller.SubmitReport();
            }
        }

        private void chbEnableSDI_CheckedChanged(object sender, EventArgs e)
        {
            // Enable/disable the SDI type dropdown based on the checkbox state
            cmbSDIDirection.Enabled = chbEnableSDI.Checked;
            nudSDIFrames.Enabled = chbEnableSDI.Checked;

            if (chbEnableSDI.Checked)
            {
                // Create a new timer and subcribe to its event
                _sdiTimer = new System.Timers.Timer();
                _sdiTimer.Elapsed += _sdiTimer_Elapsed;

                // We want to alternate SDI angles every frame by default
                _sdiTimer.Interval = 16;

                // Continously send event updates.
                _sdiTimer.AutoReset = true;

                // Start the timer
                _sdiTimer.Start();
            }

            else
            {
                // Send a neutral angle report
                _controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)Directions.angNone.X);
                _controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)Directions.angNone.Y);
                _controller.SubmitReport();


                // Dispose of the timer.
                _sdiTimer.Dispose();
            }
        }

        private void chbEnableDI_CheckedChanged(object sender, EventArgs e)
        {
            // Enable/disable the shield type dropdown based on the checkbox state
            cmbDIDirection.Enabled = chbEnableDI.Checked;
            if (chbEnableDI.Checked)
            {
                // Create a new timer and subcribe to its event
                _diTimer = new System.Timers.Timer();
                _diTimer.Elapsed += _diTimer_Elapsed;

                // Continously send event updates.
                _diTimer.AutoReset = true;

                // Start the timer
                _diTimer.Start();
            }

            else 
            {
                // Send a neutral angle report
                _controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)Directions.angNone.X);
                _controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)Directions.angNone.Y);
                _controller.SubmitReport();

                // Dispose of the old timer.
                _diTimer.Dispose();
            }
        }

        private void chbShieldHold_CheckedChanged(object sender, EventArgs e)
        {
            // Enable/disable the shield type dropdown based on the checkbox state
            cmbShieldType.Enabled = chbShieldHold.Checked;

            if (chbShieldHold.Checked)
            {
                // Create a new timer and subcribe to its event
                _shieldTimer = new System.Timers.Timer();
                _shieldTimer.Elapsed += _shieldTimer_Elapsed;

                // Continously send event updates.
                _shieldTimer.AutoReset = true;

                // Start the timer
                _shieldTimer.Start();
            }

            else
            {
                // Disable the hold numeric control
                nudShieldHoldTime.Enabled = false;

                // Submit a neutral input on the triggers.
                _controller.SetSliderValue(Xbox360Slider.LeftTrigger, 0);
                _controller.SetSliderValue(Xbox360Slider.RightTrigger, 0);
                _controller.SubmitReport();
                
                // We're done with the timer, get rid of it
                _shieldTimer.Dispose();
            }
        }

        private void _sdiTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // Use this to count up and alternate between the SDI angles
            IncrementSDIAngle();
            switch (_currentSDIAngle)
            {
                case Direction.None:
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)Directions.angNone.X);
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)Directions.angNone.Y);
                    break;
                case Direction.Forward:
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)SDIDirections.angForward[_currentSDIIDX].X);
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)SDIDirections.angForward[_currentSDIIDX].Y);
                    break;
                case Direction.Backwards:
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)SDIDirections.angBackwards[_currentSDIIDX].X);
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)SDIDirections.angBackwards[_currentSDIIDX].Y);
                    break;
                case Direction.Up:
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)SDIDirections.angUp[_currentSDIIDX].X);
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)SDIDirections.angUp[_currentSDIIDX].Y);
                    break;
                case Direction.Down:
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)SDIDirections.angDown[_currentSDIIDX].X);
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)SDIDirections.angDown[_currentSDIIDX].Y);
                    break;
                case Direction.ForwardAndUp:
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)SDIDirections.angForwardUp[_currentSDIIDX].X);
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)SDIDirections.angForwardUp[_currentSDIIDX].Y);
                    break;
                case Direction.ForwardAndDown:
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)SDIDirections.angForwardDown[_currentSDIIDX].X);
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)SDIDirections.angForwardDown[_currentSDIIDX].Y);
                    break;
                case Direction.BackandUp:
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)SDIDirections.angBackUp[_currentSDIIDX].X);
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)SDIDirections.angBackUp[_currentSDIIDX].Y);
                    break;
                case Direction.BackandDown:
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)SDIDirections.angBackDown[_currentSDIIDX].X);
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)SDIDirections.angBackDown[_currentSDIIDX].Y);
                    break;
            }

            // Submit the report
            _controller.SubmitReport();
        }

        private void _diTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            switch (_currentDIAngle)
            {
                case Direction.None:
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)Directions.angNone.X);
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)Directions.angNone.Y);
                    break;
                case Direction.Forward:
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)Directions.angForward.X);
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)Directions.angForward.Y);
                    break;
                case Direction.Backwards:
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)Directions.angBackwards.X);
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)Directions.angBackwards.Y);
                    break;
                case Direction.Up:
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)Directions.angUp.X);
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)Directions.angUp.Y);
                    break;
                case Direction.Down:
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)Directions.angDown.X);
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)Directions.angDown.Y);
                    break;
                case Direction.ForwardAndDown:
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)Directions.angForwardDown.X);
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)Directions.angForwardDown.Y);
                    break;
                case Direction.ForwardAndUp:
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)Directions.angForwardUp.X);
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)Directions.angForwardUp.Y);
                    break;
                case Direction.BackandDown:
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)Directions.angBackDown.X);
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)Directions.angBackDown.Y);
                    break;
                case Direction.BackandUp:
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)Directions.angBackUp.X);
                    _controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)Directions.angBackUp.Y);
                    break;
            }

            // Submit the report
            _controller.SubmitReport();
        }
       
        private void _shieldTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            switch(_currentShieldType)
            {
                case ShieldType.None:
                    _controller.SetSliderValue(Xbox360Slider.LeftTrigger, 0);
                    _controller.SetSliderValue(Xbox360Slider.RightTrigger, 0);
                    break;

                // Double hold the triggers so we get a hard shield in Ultimate
                case ShieldType.Hold:
                    _controller.SetSliderValue(Xbox360Slider.LeftTrigger, 255);
                    _controller.SetSliderValue(Xbox360Slider.RightTrigger, 255);
                    break;

                case ShieldType.Flash:
                    if (_shieldStatus)
                    {
                        _controller.SetSliderValue(Xbox360Slider.LeftTrigger, 0);
                        _controller.SetSliderValue(Xbox360Slider.RightTrigger, 0);
                    }

                    else
                    {
                        _controller.SetSliderValue(Xbox360Slider.LeftTrigger, 255);
                        _controller.SetSliderValue(Xbox360Slider.RightTrigger, 255);
                    }

                    // This is so we can put up / down the shield 
                    _shieldStatus = !_shieldStatus; 

                    break;
            }

            // Submit the report
            _controller.SubmitReport();
        }

        private void cmbSDIDirection_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Get the currently selected Direction for SDI
            _currentSDIAngle = (Direction)cmbSDIDirection.SelectedItem;

            // Reset the SDI index
            _currentSDIIDX = 0;
        }

        private void cmbDIDirection_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _currentDIAngle = (Direction)cmbDIDirection.SelectedItem;
        }

        private void cmbShieldType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // This gets around some tricky UI threading stuff while we're subscribed to the timer events.
            _currentShieldType = (ShieldType)cmbShieldType.SelectedItem;

            // Only enable the shield flash time if it's selected
            nudShieldHoldTime.Enabled = _currentShieldType == ShieldType.Flash;
        }

        private void cmbButton_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _currentButton = (Button)cmbButton.SelectedItem;
        }

        private void nudShieldHoldTime_ValueChanged(object sender, EventArgs e)
        {
            // 1 frame is 16ms, this resets the timer
            _shieldTimer.Interval = (double)(nudShieldHoldTime.Value * 16);
        }

        private void nudSDIFrames_ValueChanged(object sender, EventArgs e)
        {
            // 1 frame is 16ms, this resets the timer
            _sdiTimer.Interval = (double)(nudSDIFrames.Value * 16);
        }

        private void IncrementSDIAngle()
        {
            // Add the delta to the index
            _currentSDIIDX += _sdiDelta;

            // This fixes an issue I'm too lazy to figure the cause of
            if (_currentSDIIDX == -1)
                _currentSDIIDX = 0;

            // We reached 0, start adding.
            if (_currentSDIIDX == 0)
                _sdiDelta = 1;

            // We reached 2, start subtracting.
            if (_currentSDIIDX == 2)
                _sdiDelta = -1;
        }

        private enum Button
        {
            LeftTrigger, RightTrigger,
            StickLeft, StickRight,
            StickDown, StickUp
        }

        private enum ShieldType
        {
            None, Hold, Flash
        }

        
    }
}
