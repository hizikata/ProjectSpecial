/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:ProjectSpecial"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace ProjectSpecial.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<AvalonViewModel>();
            SimpleIoc.Default.Register<TestViewModel>();
            SimpleIoc.Default.Register<ValidateExceptionViewModel>();
            SimpleIoc.Default.Register<DataValidateViewModel>();
            SimpleIoc.Default.Register<ValidationRuleViewModel>();
            SimpleIoc.Default.Register<DataErrorInfoViewModel>();
            SimpleIoc.Default.Register<BindDataAnnotationsViewModel>();
            SimpleIoc.Default.Register<PackedValidateViewModel>();
            SimpleIoc.Default.Register<DispatcherHelperViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public AvalonViewModel Avalon
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AvalonViewModel>();
            }
        }
        public TestViewModel Test
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TestViewModel>();
            }
        }
        public ValidateExceptionViewModel ValidateException
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ValidateExceptionViewModel>();
            }
        }
        public DataValidateViewModel DataValidate
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DataValidateViewModel>();
            }
        }
        public ValidationRuleViewModel ValidationRule
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ValidationRuleViewModel>();
            }
        }
        public DataErrorInfoViewModel DataErrorInfo
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DataErrorInfoViewModel>();
            }
        }
        public BindDataAnnotationsViewModel BindDataAnnotation
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BindDataAnnotationsViewModel>();
            }
        }
        public PackedValidateViewModel PackedValidate
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PackedValidateViewModel>();
            }
        }
        public DispatcherHelperViewModel DispatcherHelper
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DispatcherHelperViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}