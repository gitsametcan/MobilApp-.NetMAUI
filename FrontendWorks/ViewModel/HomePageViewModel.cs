using FrontendWorks.Models;
using FrontendWorks.Service;
using FrontendWorks.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendWorks.ViewModel
{
    public class HomePageViewModel : BaseViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<DaskPolicy> _dask;

        private readonly IPolicyRepo _policyRepo;
        public ObservableCollection<DaskPolicy> Dask
        {
            get { return _dask; }
            set
            {
                _dask = value;
                OnPropertyChanged(nameof(Dask));
            }
        }
        public HomePageViewModel(IPolicyRepo policyServices) { 
            _policyRepo = policyServices;
            LoadDaskList(_policyRepo);
            Title = "asdas";



        }

        private async void LoadDaskList(IPolicyRepo policyServices)
        {
            List<DaskPolicy> daskPolicies = await policyServices.GetDaskPolicyById(1, " ");
            Dask =  new ObservableCollection<DaskPolicy>(daskPolicies);
            
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
