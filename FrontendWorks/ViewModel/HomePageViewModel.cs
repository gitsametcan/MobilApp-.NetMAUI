using CommunityToolkit.Mvvm.Input;
using FrontendWorks.Models;
using FrontendWorks.Service;
using FrontendWorks.Views;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendWorks.ViewModel
{
    public partial class HomePageViewModel : BaseViewModel
    {

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
            Title = "My Dask Policies";
            

        }

        
        async Task LoadDaskList(IPolicyRepo policyServices)
        {
            List<DaskPolicy> daskPolicies = await policyServices.GetDaskPolicyById(1, " ");
            Dask =  new ObservableCollection<DaskPolicy>(daskPolicies);
            
        }

        
    }
}
