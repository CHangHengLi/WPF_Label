using System;

namespace WPF_Label
{
    public static class LangRes
    {
        // 定义当前语言枚举
        public enum Language { Chinese, English }
        
        // 当前语言设置
        private static Language _currentLanguage = Language.Chinese;
        
        // 语言变更事件
        public static event EventHandler LanguageChanged;
        
        // 当前语言属性
        public static Language CurrentLanguage
        {
            get { return _currentLanguage; }
            set 
            { 
                if (_currentLanguage != value)
                {
                    _currentLanguage = value;
                    LanguageChanged?.Invoke(null, EventArgs.Empty);
                }
            }
        }
        
        // 动态语言资源
        public static string UsernameLabel
        {
            get
            {
                return _currentLanguage == Language.Chinese 
                    ? "用户名（中文）:" 
                    : "Username (English):";
            }
        }
        
        public static string PasswordLabel
        {
            get
            {
                return _currentLanguage == Language.Chinese 
                    ? "密码（中文）:" 
                    : "Password (English):";
            }
        }
        
        // 切换语言方法
        public static void ToggleLanguage()
        {
            CurrentLanguage = _currentLanguage == Language.Chinese 
                ? Language.English 
                : Language.Chinese;
        }
    }
} 