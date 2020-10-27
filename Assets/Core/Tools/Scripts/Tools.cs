using System;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;
//using chat system

namespace LangerNetwork
{
    public partial class Tools
    {
        protected const char CONST_DELIMITER = ';';
        internal const int MIN_LENGTH_NAME = 4;
        internal const int MAX_LENGTH_NAME = 16;
        #region TrimExcessWhitespace
        public static string TrimExcessWhitespace(string input, bool trimAllWhitespace = false)
        {
            int len = input.Length,
                index = 0,
                i = 0;
            var src = input.ToCharArray();
            bool skip = false;
            char ch;
            for(; i < len; i ++)
            {
                ch = src[i];
                switch(ch)
                {
                    case '\u0020':
                    case '\u00A0':
                    case '\u1680':
                    case '\u2000':
                    case '\u2001':
                    case '\u2002':
                    case '\u2003':
                    case '\u2004':
                    case '\u2005':
                    case '\u2006':
                    case '\u2007':
                    case '\u2008':
                    case '\u2009':
                    case '\u200A':
                    case '\u202F':
                    case '\u205F':
                    case '\u3000':
                    case '\u2028':
                    case '\u2029':
                    case '\u0009':
                    case '\u000A':
                    case '\u000B':
                    case '\u000C':
                    case '\u000D':
                    case '\u0085':
                        if (skip || trimAllWhitespace) continue;
                        src[index++] = ch;
                        skip = true;
                        continue;
                    default:
                        skip = false;
                        src[index++] = ch;
                        continue;
                }
            }

            return new string(src, 0, index);
        }
        #endregion

        public static string GetPath(string fileName)
        {
#if UNITY_EDITOR
            return Path.Combine(Directory.GetParent(Application.dataPath).FullName, fileName);
#elif UNITY_ANDROID
        	return Path.Combine(Application.persistentDataPath, fileName);
#elif UNITY_IOS
        	return Path.Combine(Application.persistentDataPath, fileName);
#else
			return Path.Combine(Application.dataPath, fileName);
#endif
        }

        public static string GenerateHash(string encryptText, string saltText)
        {
            return Tools.PBKDF2Hash(encryptText, ProjectConfigTemplate.singleton.securitySalt + saltText);
        }

        public static int GetArrayHashCode(object[] array)
        {
            if(array != null)
            {
                unchecked
                {
                    int hash = 17;
                    foreach (var item in array)
                        hash = hash * 23 + ((item != null) ? item.GetHashCode() : 0);
                    return hash;
                }
            }
            return 0;
        }

        public static string GetRandomAlphaString(int length=4)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[UnityEngine.Random.Range(0, s.Length)]).ToArray());
        }

        public static string GetDeviceId
        {
            get
            {
                return SystemInfo.deviceUniqueIdentifier.ToString();
            }
        }

        public static int GetArgumentInt(string name)
        {
            string[] args = Environment.GetCommandLineArgs();
            int idx = args.ToList().FindIndex(x => x == name);
            if (idx == -1 || idx == args.Length)
                return -1;
            return int.Parse(args[idx + 1]);
        }

        public static string GetArgumentString
        {
            get
            {
                string[] args = Environment.GetCommandLineArgs();
                return args != null ? String.Join(" ", args.Skip(1).ToArray()) : "";
            }
        }

        public static string GetProcessPath
        {
            get
            {
                string[] args = Environment.GetCommandLineArgs();
                if (args != null)
                    if (!String.IsNullOrWhiteSpace(args[0]))
                        return args[0];
                return String.Empty;
            }
        }

        public static bool IsAllowedName(string textToCheck)
        {
            return textToCheck.Length >= MIN_LENGTH_NAME &&
                    textToCheck.Length <= MAX_LENGTH_NAME &&
                    Regex.IsMatch(textToCheck, @"^[a-zA-Z0-9_" + " " + "]+$") && //ALLOWED LETTERS & SYMBOLS & BLANK SPACES
                    (textToCheck[textToCheck.Length - 1] != ' ') && //LAST CHARACTER NOT WHITESPACE
                    (textToCheck[0] != ' '); //FIRST CHARACTER NOT WHITESPACE
                    //(!ChatManager.singleton.profanityFilter.FilterText(textToCheck).Contains(ChatManager.ProfanityMask)); //DOES NOT CONTAIN PROFANITY //TODO: Enable Chat Manager Filtering
        }

        public static bool IsAllowedPassword(string _text)
        {
            return !String.IsNullOrWhiteSpace(_text);
        }

        public static string PBKDF2Hash(string text, string salt)
        {
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(text, saltBytes, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }

        public static string IntArrayToString(int[] array)
        {
            if (array == null || array.Length == 0) return null;
            string arrayString = "";
            for(int i = 0; i < array.Length; i++)
            {
                arrayString += array[i].ToString();
                if (i < array.Length - 1)
                    arrayString += CONST_DELIMITER;
            }
            return arrayString;
        }

        public static int[] IntStringToArray(string array)
        {
            if (string.IsNullOrWhiteSpace(array)) return null;
            string[] tokens = array.Split(CONST_DELIMITER);
            int[] arrayInt = Array.ConvertAll<string, int>(tokens, int.Parse);
            return arrayInt;
        }

        public static bool ArrayContains(int[] array, int number)
        {
            foreach (int element in array)
            {
                if (element == number)
                    return true;
            }
            return false;
        }

        public static bool ArrayContains(string[] array, string text, bool toLower = true)
        {
            foreach (string element in array)
            {
                if (toLower && text.ToLower().IndexOf(element.ToLower()) != -1)
                    return true;
                else if (text.IndexOf(element) != -1)
                    return true;
            }
            return false;
        }

        public static string[] RemoveFromArray(string[] array, string text)
        {
            return array.Where(x => x != text).ToArray();
        }

        public static int[] RemoveFromArray(int[] array, int number)
        {
            return array.Where(x => x != number).ToArray();
        }

        public static void PlayerPrefsSetString(string keyName, string newValue, string oldValue="", bool set=false)
        {
            if (PlayerPrefs.HasKey(keyName) || set)
                if ((!set && PlayerPrefs.GetString(keyName) == oldValue) || (!set && oldValue == "") || set)
                    PlayerPrefs.SetString(keyName, newValue);
        }

        public static void PlayerPrefsSetInt(string keyName, int newValue, int oldValue=-1, bool set=false)
        {
            if (PlayerPrefs.HasKey(keyName) || set)
                if ((!set && PlayerPrefs.GetInt(keyName) == oldValue) || (!set && oldValue == -1) || set)
                    PlayerPrefs.SetInt(keyName, newValue);
        }

        public static bool AnyInputFocused
        {
            get
            {
                foreach (Selectable selectable in Selectable.allSelectablesArray)
                    if (selectable is InputField && ((InputField)selectable).isFocused)
                        return true;
                return false;
            }
        }

        public static float ClampAngleBetweenMinAndMax(float angle, float min, float max)
        {
            if (angle < -360)
                angle += 360;
            if (angle > 360)
                angle -= 360;
            return Mathf.Clamp(angle, min, max);
        }
    }
}