using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Backend;

namespace WPF.MainForms
{
    public interface IProfileRequester
    {
        void ProfileComplete(ProfileModel profile);
    }
}
