using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalMemo.Views
{

    public class FoladerViewModelMasterMenuItem
    {
        public FoladerViewModelMasterMenuItem()
        {
            TargetType = typeof(FoladerViewModelMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}