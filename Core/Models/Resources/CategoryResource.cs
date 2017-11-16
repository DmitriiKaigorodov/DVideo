using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DVideo.Core.Models.Resources
{
    public class CategoryResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  ICollection<KeyValuePairResource> Subcategories { get; set; }

        public CategoryResource()
         {
             Subcategories = new Collection<KeyValuePairResource>();
         }
    }


}