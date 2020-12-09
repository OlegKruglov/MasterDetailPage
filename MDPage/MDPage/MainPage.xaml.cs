using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MDPage
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            profileImage.Source = ImageSource.FromFile("marvel.webp");
            aboutList.ItemsSource = GetMenuList();
            var homePage = typeof(View.BlackPanther);
            Detail = new NavigationPage((Page)Activator.CreateInstance(homePage));
            IsPresented = false;
        }

        public List<MasterMenuItems> GetMenuList()
        {
            var list = new List<MasterMenuItems>();
            list.Add(new MasterMenuItems()
            {
                Text="Железный Человек",
                Detail="Дебют:1963г.",
                ImagePath="ironMan.jpg",
                TargetPage=typeof(View.BlackPanther)
            });
            
            return list;
        }

        private void aboutList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedMenuItem = (MasterMenuItems)e.SelectedItem;
            Type selectedPage = selectedMenuItem.TargetPage;
            Detail = new NavigationPage((Page)Activator.CreateInstance(selectedPage));
            IsPresented = false;
        }
    }
}
