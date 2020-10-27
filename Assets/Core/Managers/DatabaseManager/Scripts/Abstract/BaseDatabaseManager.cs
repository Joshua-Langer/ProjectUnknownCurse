using System;
using LangerNetwork.Debugging;
using LangerNetwork;
using UnityEngine;

namespace LangerNetwork.Database
{
    public abstract partial class BaseDatabaseManager : MonoBehaviour, IAccountableManager
    {
        [Header("Debug Helper")]
        public DebugHelper debug = new DebugHelper();

        public virtual void Awake() { }

        public virtual bool TryUserLogin(string userName, string userPassword)
        {
            return (Tools.IsAllowedName(userName) && Tools.IsAllowedPassword(userPassword));
        }

        public virtual bool TryUserRegister(string userName, string userPassword, string eMail, string deviceId)
        {
            return (Tools.IsAllowedName(userName) && Tools.IsAllowedPassword(userPassword));
        }

        public virtual bool TryUserDelete(string userName, string userPassword, DatabaseAction databaseAction = DatabaseAction.Do)
        {
            return (Tools.IsAllowedName(userName) && Tools.IsAllowedPassword(userPassword));
        }

        public virtual bool TryUserBan(string userName, string userPassword, DatabaseAction databaseAction = DatabaseAction.Do)
        {
            return (Tools.IsAllowedName(userName) && Tools.IsAllowedPassword(userPassword));
        }

        public virtual bool TryUserChangePassword(string userName, string oldPassword, string newPassword)
        {
            return (Tools.IsAllowedName(userName) && Tools.IsAllowedPassword(oldPassword) && Tools.IsAllowedPassword(newPassword) && oldPassword != newPassword);
        }

        public virtual bool TryUserConfirm(string userName, string userPassword, DatabaseAction databaseAction = DatabaseAction.Do)
        {
            return (Tools.IsAllowedName(userName) && Tools.IsAllowedPassword(userPassword));
        }

        public virtual bool TryUserGetValid(string userName, string userPassword)
        {
            return (Tools.IsAllowedName(userName) && Tools.IsAllowedPassword(userPassword));
        }

		public virtual bool TryUserGetExists(string userName)
		{
			return (Tools.IsAllowedName(userName));
		}

		public virtual bool TryPlayerLogin(string playerName, string userName)
		{
			return (Tools.IsAllowedName(playerName) && Tools.IsAllowedName(userName));
		}

		public virtual bool TryPlayerRegister(string playerName, string userName, string prefabName)
		{
			return (Tools.IsAllowedName(playerName) && Tools.IsAllowedName(userName) && !String.IsNullOrWhiteSpace(prefabName));
		}

		public virtual bool TryPlayerDeleteSoft(string playerName, string userName, DatabaseAction databaseAction = DatabaseAction.Do)
		{
			return (Tools.IsAllowedName(playerName) && Tools.IsAllowedName(userName));
		}

		public virtual bool TryPlayerDeleteHard(string playerName, string userName)
		{
			return (Tools.IsAllowedName(playerName) && Tools.IsAllowedName(userName));
		}

		public virtual bool TryPlayerBan(string playerName, string userName, DatabaseAction databaseAction = DatabaseAction.Do)
		{
			return (Tools.IsAllowedName(playerName) && Tools.IsAllowedName(userName));
		}

		public abstract int TryUserGetPlayerCount(string userName);
	}
}
