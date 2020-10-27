using LangerNetwork;
using System;

namespace LangerNetwork.Network
{
    [Serializable]
    public partial class NetworkManager_Lang
    {
        public string clientDisconnected = "Disconnected";
        public string userAlreadyOnline = "User is already Online!";

        public string userLoginSuccess = "";
        public string userLoginFailure = "Account Login failed";
        public string userRegisterSuccess = "Account Registration successful!";
        public string userRegisterFailure = "Account Registration failed!";
        public string userChangePasswordSuccess = "Change Password Successful!";
        public string userChangePasswordFailure = "Change Password Failed!";
        public string userDeleteSuccess = "Delete Account successful!";
        public string userDeleteFailed = "Delete Account Failed!";
        public string userConfirmSuccess = "Account Confirmed!";
        public string userConfirmFailed = "Confirm Failed!";
        public string playerLoginSuccess = "";
        public string playerLoginFailure = "Player Login Failed!";
        public string playerRegisterSuccess = "Create Player successful!";
        public string playerRegisterFailed = "Create player failed!";
        public string playerDeleteSuccess = "Delete Player Successful!";
        public string playerDeleteFailed = "Delete Player Failed!";
        public string playerSwitchServerSuccess = "Server swith successful!";
        public string playerSwitchServerFailed = "Server switch failed!";
        public string unknownError = "Unknown error.";
    }
}
