using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TravelApp.Models;

namespace TravelApp.Modelview
{
    class CategorymodelView
    {
        public IList<Category> CategoryList { get; set; }

        public CategorymodelView()
        {
            try
            {
                CategoryList = new ObservableCollection<Category>();
                CategoryList.Add(new Category { Categorytype = "Work" });
                CategoryList.Add(new Category { Categorytype = "indoor Fun" });
                CategoryList.Add(new Category { Categorytype = "Outdoor scenery" });
                CategoryList.Add(new Category { Categorytype = "Restaurant and Hotel" });
                CategoryList.Add(new Category { Categorytype = "Outdoor Fun" });
                CategoryList.Add(new Category { Categorytype = "Study" });


            }
            catch (Exception ex)
            {

            }
        }
    }
}
