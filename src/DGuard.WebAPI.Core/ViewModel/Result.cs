using System.Collections.Generic;

namespace DGuard.WebAPI.Core.ViewModel
{
    public class Result<TModel>
    {
        public bool Sucess { get; set; }
        public TModel Model { get; set; }
        public EnumMessage Message { get; set; }
        public ICollection<string> Errors { get; set; }
    }
    public enum EnumMessage
    {

        Ok = 0,
        Error = 1
    }
}
