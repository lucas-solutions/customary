using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Areas.Admin.Models
{
    using Custom.Models;

    public class ModelViewModel : ViewModel
    {
        private ProxyViewModel _proxy;
        private List<FieldViewModel> _fields;
        private List<AssociationViewModel> _associations;
        private List<ValidationViewModel> _validations;

        public ProxyViewModel Proxy
        {
            get { return _proxy ?? (_proxy = new ProxyViewModel()); }
            set { _proxy = value; }
        }

        public List<FieldViewModel> Fields
        {
            get { return _fields ?? (_fields = new List<FieldViewModel>()); }
            set { _fields = value; }
        }

        public List<AssociationViewModel> Associations
        {
            get { return _associations ?? (_associations = new List<AssociationViewModel>()); }
            set { _associations = value; }
        }
        
        public List<ValidationViewModel> Validations
        {
            get { return _validations ?? (_validations = new List<ValidationViewModel>()); }
            set { _validations = value; }
        }
    }
}