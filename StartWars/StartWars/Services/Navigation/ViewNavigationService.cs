using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Reflection;

namespace StartWars.Services.Navigation
{
    public interface IViewNavigationService
    {
        string CurrentPageKey { get; }

        void Configure(string pageKey, Type pageType);
        void Initialize(NavigationPage page);
        void GoBack();
        void NavigateTo(string pageKey);
        void NavigateTo(string pageKey, object parameter);
        Dictionary<string, Type> GetDictionary();
        void InsertPageBefore(string pageKey);

    }
    public class ViewNavigationService : IViewNavigationService
    {
        private readonly Dictionary<string, Type> _pagesByKey = new Dictionary<string, Type>();
        private NavigationPage _navigation;

        public Dictionary<string, Type> GetDictionary()
        {
            return _pagesByKey;
        }
        public string CurrentPageKey
        {
            get
            {
                lock (_pagesByKey)
                {
                    if (_navigation.CurrentPage == null)
                    {
                        return null;
                    }

                    var pageType = _navigation.CurrentPage.GetType();

                    return _pagesByKey.ContainsValue(pageType)
                                      ? _pagesByKey.First(p => p.Value == pageType).Key.ToString() : null;
                }
            }
        }

        public void GoBack()
        {
            if (CanGoBack())
            {
                _navigation.PopAsync();
            }
        }

        public bool CanGoBack()
        {
            return _navigation.Navigation?.NavigationStack?.Count > 1;
        }
        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }
        public void InsertPageBefore(string pageKey)
        {
            // if (_pagesByKey.ContainsKey(pageKey))
            // {//
            // var type = _pagesByKey[pageKey];
            this._navigation.Navigation.InsertPageBefore(GetPaget(pageKey, null), this._navigation.Navigation.NavigationStack[0]);
            this._navigation.PopToRootAsync(false);
            //}
        }


        private Page GetPaget(string pageKey, object parameter=null)
        {
            lock (_pagesByKey)
            {

                if (_pagesByKey.ContainsKey(pageKey))
                {
                    var type = _pagesByKey[pageKey];
                    ConstructorInfo constructor;
                    object[] parameters;

                    if (parameter == null)
                    {
                        constructor = type.GetTypeInfo()
                            .DeclaredConstructors
                            .FirstOrDefault(c => !c.GetParameters().Any());

                        parameters = new object[]
                        {
                        };
                    }
                    else
                    {
                        constructor = type.GetTypeInfo()
                            .DeclaredConstructors
                            .FirstOrDefault(
                                c =>
                                {
                                    var p = c.GetParameters();
                                    return p.Count() == 1
                                           && p[0].ParameterType == parameter.GetType();
                                });

                        parameters = new[]
                        {
                            parameter
                        };
                    }

                    if (constructor == null)
                    {
                        throw new InvalidOperationException(
                            "No suitable constructor found for page " + pageKey);
                    }

                    //var page = 
                    return constructor.Invoke(parameters) as Page;
                    // _navigation.PushAsync(page);
                }
                else
                {
                    throw new ArgumentException(
                        string.Format(
                            "No such page: {0}. Did you forget to call NavigationService.Configure?",
                            pageKey), nameof(pageKey));
                }
            }
        }


        public void NavigateTo(string pageKey, object parameter)
        {
            lock (_pagesByKey)
            {

                if (_pagesByKey.ContainsKey(pageKey))
                {
                    var type = _pagesByKey[pageKey];
                    ConstructorInfo constructor;
                    object[] parameters;

                    if (parameter == null)
                    {
                        constructor = type.GetTypeInfo()
                            .DeclaredConstructors
                            .FirstOrDefault(c => !c.GetParameters().Any());

                        parameters = new object[]
                        {
                        };
                    }
                    else
                    {
                        constructor = type.GetTypeInfo()
                            .DeclaredConstructors
                            .FirstOrDefault(
                                c =>
                                {
                                    var p = c.GetParameters();
                                    return p.Count() == 1
                                           && p[0].ParameterType == parameter.GetType();
                                });

                        parameters = new[]
                        {
                            parameter
                        };
                    }

                    if (constructor == null)
                    {
                        throw new InvalidOperationException(
                            "No suitable constructor found for page " + pageKey);
                    }

                    var page = constructor.Invoke(parameters) as Page;
                    _navigation.PushAsync(page);
                }
                else
                {
                    throw new ArgumentException(
                        string.Format(
                            "No such page: {0}. Did you forget to call NavigationService.Configure?",
                            pageKey), nameof(pageKey));
                }
            }
        }

        public void Configure(string pageKey, Type pageType)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(pageKey))
                {
                    _pagesByKey[pageKey] = pageType;
                }
                else
                {
                    _pagesByKey.Add(pageKey, pageType);
                }
            }
        }

        public void Initialize(NavigationPage navigation)
        {
            _navigation = navigation;
        }
    }
}