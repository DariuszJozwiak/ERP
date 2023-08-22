
using ERPNavi.Helpers;
using ERPNavi.Views;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace ERPNavi.ViewModels
{
    public  class MainWindowViewModel : BaseViewModel
    {
        //będzie zawierała kolekcje komend, które pojawiają się w menu lewym oraz kolekcje zakładek 
        #region Komendy menu i paska narzedzi
        public ICommand NowyTowarCommand //ta komenda zostanie podpieta pod menu i pasek narzedzi
        { 
            get
            {
                return new BaseCommand(() => createView(new NowyTowarViewModel()));//to jest komenda, która wyw. funkcję createTowar
                                                                                   // return new BaseCommand(()=>createView(new NowyTowarViewModel()));//to jest komenda, która wyw. funkcję createTowar
            }
        }
        public ICommand TowaryCommand
        {

            get
            {
                return new BaseCommand(showAllTowar);
               
            }
        }
        public ICommand NowaFakturaCommand 
        {
            get
            {
                return new BaseCommand(() => createView(new NowaFakturaViewModel()));
            }
        }
        public ICommand FakturyCommand
        {
            get
            {
                return new BaseCommand(() => createView(new WszystkieFakturyViewModel()));
              //  return new BaseCommand(showAllFaktury);
            }
        }

        public ICommand PrzetargiCommand
        {
            get
            {
                return new BaseCommand(showAllPrzetargi);
            }
        }

        public ICommand NowyPrzetargCommand
        {
            get
            {
                return new BaseCommand(showNowyPrzetargViewModel);
            }
        }


        public ICommand BibliotekaDokumentowCommand
        {
            get
            {
                return new BaseCommand(showBibliotekaDokumentowViewModel);
            }
        }
        public ICommand ZamowieniaOdKlientaCommand
        {
            get
            {
                return new BaseCommand(showZamowieniaOdKLientowViewModel);
            }
        }

        public ICommand KontrahenciCommand
        {
            get
            {
                return new BaseCommand(showKontrahenciViewModel);
            }
        }

        public ICommand KadryCommand
        {
            get
            {
                return new BaseCommand(showKadryViewModel);
            }
        }


        public ICommand StanyMagazynoweCommand
        {
            get
            {
                return new BaseCommand(showStanyMagazynoweViewModel);
            }
        }

        public ICommand StratyMagazynoweCommand
        {
            get
            {
                return new BaseCommand(showStratyMagazynoweViewModel);
            }
        }

        public ICommand KorektaFakturyCommand
        {
            get
            {
                return new BaseCommand(showKorektaFakturyViewModel);
            }
        }

        public ICommand ZamowieniaWMSCommand
        {
            get
            {
                return new BaseCommand(showZamowieniaWMSViewModel);
            }
        }

        public ICommand RaportSprzedazyCommand
        {
            get
            {
                return new BaseCommand(showRaportSprzedazyViewModel);
            }
        }

        public ICommand RaportKontrahenciCommand
        {
            get
            {
                return new BaseCommand(showRaportKontrahentowViewModel);
            }
        }

        public ICommand ModyfikujFaktureCommand
        {
            get
            {
                return new BaseCommand(showModyfikujFaktureViewModel);
            }
        }

        public ICommand NowyPracownikKadrCommand
        {
            get
            {
                return new BaseCommand(showNowyPracownikKadrViewModel);
            }
        }
        public ICommand NoweZamowienieOdKlientaCommand
        {
            get
            {
                return new BaseCommand(showShowNoweZamowienieOdKlienowViewModel);
            }
        }








        #region Przyciski w menu z lewej strony
        private ReadOnlyCollection<CommandViewModel> _Commands;//to jest kolekcja komend w menu lewym
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get 
            { 
                if(_Commands == null)//sprawdzam czy przyciski z lewej strony menu nie zostały zainicjalizowane
                {
                    List<CommandViewModel> cmds = this.CreateCommands();//tworzę listę przyciskow za pomocą funkcji CreateCommands
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);//tę listę przypisuje do ReadOnlyCollection (bo readOnlyCollection można tylko tworzyć, nie można do niej dodawać)
                }
                return _Commands; 
            }   
        }
        private List<CommandViewModel> CreateCommands()//tu decydujemy jakie przyciski są w lewym menu
        {
            registered();

            return new List<CommandViewModel>
            {
                new CommandViewModel("Towary i usługi",new BaseCommand(showAllTowar)), //to tworzy pierwszy przycisk o nazwie "Towary i usługi", który pokaże zakładkę wszystkie towary
                new CommandViewModel("Dodaj towar",new BaseCommand(()=>createView(new NowyTowarViewModel()))),
                new CommandViewModel("Nowa faktura",new BaseCommand(()=>createView(new NowaFakturaViewModel()))),
                new CommandViewModel("Wydania zewnętrzne",new BaseCommand(()=>createView(new WszystkieFakturyViewModel()))),
              //  new CommandViewModel("Wydania zewnętrzne",new BaseCommand(showAllFaktury)),
                new CommandViewModel("Przetargi",new BaseCommand(showAllPrzetargi)),
                new CommandViewModel("Dodaj przetarg",new BaseCommand(showNowyPrzetargViewModel)),
                new CommandViewModel("Biblioteka dokumentow",new BaseCommand(showBibliotekaDokumentowViewModel)),
                new CommandViewModel("Nowy dokument biblioteki",new BaseCommand(showNowyDokumentBibliotekiViewModel)),
                new CommandViewModel("Zamowienia od Klientów",new BaseCommand(showZamowieniaOdKLientowViewModel)),
                new CommandViewModel("Kontrahenci",new BaseCommand(showKontrahenciViewModel)),
                new CommandViewModel("Kardy",new BaseCommand(showKadryViewModel)),
                new CommandViewModel("Stany magazynowe",new BaseCommand(showStanyMagazynoweViewModel)),
                new CommandViewModel("Straty magazynowe",new BaseCommand(showStratyMagazynoweViewModel)),
                new CommandViewModel("Korekta faktury",new BaseCommand(showKorektaFakturyViewModel)),
                new CommandViewModel("Zamówienia WMS",new BaseCommand(showZamowieniaWMSViewModel)),
                new CommandViewModel("Utarg",new BaseCommand(showRaportSprzedazyViewModel)),
                new CommandViewModel("Raport kontrahentow",new BaseCommand(showRaportKontrahentowViewModel)),
                new CommandViewModel("Modyfikuj Fakture",new BaseCommand(showModyfikujFaktureViewModel)),
                new CommandViewModel("Nowy pracownik kadr",new BaseCommand(showNowyPracownikKadrViewModel)),
                new CommandViewModel("Nowe zamowienie od klienta",new BaseCommand(showShowNoweZamowienieOdKlienowViewModel)),
              
            };
        }


        public event EventHandler RequestClose;
        public void OnRequestClose()
        {
            EventHandler handler = this.RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        #endregion

        #region Zakładki
        private ObservableCollection<WorkspaceViewModel> _Workspaces; //to jest kolekcja zakładek
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get 
            {
                if(_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.onWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void onWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.onWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.onWorkspaceRequestClose;
        }
        private void onWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }
        #endregion
        #region Funkcje pomocnicze
        /// <summary>
        /// Ta metoda zostanie wywołania przez Messenger w momencie otrzymania określonej wiadomości.
        /// </summary>
        /// <param name="name">Wiadomość</param>
        ///
        private void registered()
        { 
         
            Messenger.Default.Register<string>(this, item => open(item));
            
        }
          
        private void open(string name)
        {
            if (name == "Faktury Add")
            {

                createView(new NowaFakturaViewModel());
            }
            if (name == "Add")
            {

                createView(new NowaFakturaViewModel());
            }
            else if (name == "Towary Add")
            {
                createView(new NowyTowarViewModel());
            }
            else if (name == "Kontrahenci Add")
            {
             //   createView(new NowyKontrahentViewModel());
            }
            else if (name == "Kontrahenci Show")
            {
                showAllKontrahenci();
            }
            else if (name == "Pozycja faktury Add")
            {
                // createView(new NowaPozycjaFakturyViewModel());
                WindowComposer.OpenNewWindow(new NowaPozycjaFakturyViewModel());
            }
            else if (name == "Faktury Show")
            {
                createView(new NowaFakturaViewModel());
            }

            else if (name == "Faktury Delete")
            {
              
            }


        }





        private void createView(WorkspaceViewModel workspace)
        {
            this.Workspaces.Add(workspace);
            this.setActiveWorkspace(workspace);
        }
        private void showAllFaktury()
        {
            WszystkieFakturyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieFakturyViewModel) as WszystkieFakturyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieFakturyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
      
        //to jest funkcja, która otwiera nową zakładke Towar
        //za każdym tworzy nową NOWĄ zakładkę do dodawania towaru
        //private void createTowar()
        //{
        //    //tworzy zakładke NowyTowar (VM)
        //    NowyTowarViewModel workspace=new NowyTowarViewModel();
        //    //dodajmy ją do kolkcji aktywnych zakładek
        //    this.Workspaces.Add(workspace);
        //    this.setActiveWorkspace(workspace);
        //}
        //to jest funkcja, która otwiera zakładke ze wszystkimi towarami
        //za każdym razem sprawdza czy zakladka z towarami jest juz otwarta, jak jest to ja aktywuje, ajk nie ma to tworzy 
        private void showAllTowar()
        {
           
            WszystkieTowaryViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieTowaryViewModel) as WszystkieTowaryViewModel;
          
            if(workspace == null)
            {
                //tworzymy nowa zakladke Wszystkie towary
                workspace=new WszystkieTowaryViewModel();
                //i dodajemy ja do kolekcji zakladek
                this.Workspaces.Add(workspace);
            }
            //aktywujemy zakladke
            this.setActiveWorkspace(workspace);
        }

        private void showAllKontrahenci()
        {
            //sz....
            KontrahenciViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is KontrahenciViewModel) as KontrahenciViewModel;
            //jezeli ....
            if (workspace == null)
            {
                //tworzymy nowa zakladke Wszystkie towary
                workspace = new KontrahenciViewModel();
                //i dodajemy ja do kolekcji zakladek
                this.Workspaces.Add(workspace);
            }
            //aktywujemy zakladke
            this.setActiveWorkspace(workspace);
        }
        private void showNowyTowarViewModel()
        {

            NowyTowarViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NowyTowarViewModel) as NowyTowarViewModel;

            if (workspace == null)
            {
                //tworzymy nowa zakladke Wszystkie towary
                workspace = new NowyTowarViewModel();
                //i dodajemy ja do kolekcji zakladek
                this.Workspaces.Add(workspace);
            }
            //aktywujemy zakladke
            this.setActiveWorkspace(workspace);
        }

        private void showAllPrzetargi()
        {

            PrzetargiViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is PrzetargiViewModel) as PrzetargiViewModel;

            if (workspace == null)
            {
                //tworzymy nowa zakladke Wszystkie towary
                workspace = new PrzetargiViewModel();
                //i dodajemy ja do kolekcji zakladek
                this.Workspaces.Add(workspace);
            }
            //aktywujemy zakladke
            this.setActiveWorkspace(workspace);
        }

        private void showNowyPrzetargViewModel()
        {
            NowyPrzetargViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NowyPrzetargViewModel) as NowyPrzetargViewModel;

            if (workspace == null)
            {
                //tworzymy nowa zakladke Wszystkie towary
                workspace = new NowyPrzetargViewModel();
                //i dodajemy ja do kolekcji zakladek
                this.Workspaces.Add(workspace);
            }
            //aktywujemy zakladke
            this.setActiveWorkspace(workspace);

        }

        private void showNowaFakturaViewModel()
        {
            NowaFakturaViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NowaFakturaViewModel) as NowaFakturaViewModel;

            if (workspace == null)
            {
                //tworzymy nowa zakladke Wszystkie towary
                workspace = new NowaFakturaViewModel();
                //i dodajemy ja do kolekcji zakladek
                this.Workspaces.Add(workspace);
            }
            //aktywujemy zakladke
            this.setActiveWorkspace(workspace);

        }

        private void showBibliotekaDokumentowViewModel()
        {
            BibliotekaDokumentowViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is BibliotekaDokumentowViewModel) as BibliotekaDokumentowViewModel;

            if (workspace == null)
            {
                //tworzymy nowa zakladke Wszystkie towary
                workspace = new BibliotekaDokumentowViewModel();
                //i dodajemy ja do kolekcji zakladek
                this.Workspaces.Add(workspace);
            }
            //aktywujemy zakladke
            this.setActiveWorkspace(workspace);

        }

        private void showNowyDokumentBibliotekiViewModel()
        {
            NowyDokumentBibiotekiViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NowyDokumentBibiotekiViewModel) as NowyDokumentBibiotekiViewModel;

            if (workspace == null)
            {
                //tworzymy nowa zakladke Wszystkie towary
                workspace = new NowyDokumentBibiotekiViewModel();
                //i dodajemy ja do kolekcji zakladek
                this.Workspaces.Add(workspace);
            }
            //aktywujemy zakladke
            this.setActiveWorkspace(workspace);

        }

       private void showZamowieniaOdKLientowViewModel()
        {
            ZamowieniaOdKlientowViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is ZamowieniaOdKlientowViewModel) as ZamowieniaOdKlientowViewModel;

            if (workspace == null)
            {
                //tworzymy nowa zakladke Wszystkie towary
                workspace = new ZamowieniaOdKlientowViewModel();
                //i dodajemy ja do kolekcji zakladek
                this.Workspaces.Add(workspace);
            }
            //aktywujemy zakladke
            this.setActiveWorkspace(workspace);

        }

        private void showKontrahenciViewModel()
        {
            KontrahenciViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is KontrahenciViewModel) as KontrahenciViewModel;

            if (workspace == null)
            {
                //tworzymy nowa zakladke Wszystkie towary
                workspace = new KontrahenciViewModel();
                //i dodajemy ja do kolekcji zakladek
                this.Workspaces.Add(workspace);
            }
            //aktywujemy zakladke
            this.setActiveWorkspace(workspace);

        }

        private void showKadryViewModel()
        {
            KadryViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is KadryViewModel) as KadryViewModel;

            if (workspace == null)
            {
                //tworzymy nowa zakladke Wszystkie towary
                workspace = new KadryViewModel();
                //i dodajemy ja do kolekcji zakladek
                this.Workspaces.Add(workspace);
            }
            //aktywujemy zakladke
            this.setActiveWorkspace(workspace);

        }  
        private void showStanyMagazynoweViewModel()
        {
            StanyMagazynoweViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is StanyMagazynoweViewModel) as StanyMagazynoweViewModel;

            if (workspace == null)
            {
                //tworzymy nowa zakladke Wszystkie towary
                workspace = new StanyMagazynoweViewModel();
                //i dodajemy ja do kolekcji zakladek
                this.Workspaces.Add(workspace);
            }
            //aktywujemy zakladke
            this.setActiveWorkspace(workspace);

        } 
        private void showStratyMagazynoweViewModel()
        {
            StratyMagazynoweViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is StratyMagazynoweViewModel) as StratyMagazynoweViewModel;

            if (workspace == null)
            {
                //tworzymy nowa zakladke Wszystkie towary
                workspace = new StratyMagazynoweViewModel();
                //i dodajemy ja do kolekcji zakladek
                this.Workspaces.Add(workspace);
            }
            //aktywujemy zakladke
            this.setActiveWorkspace(workspace);

        }
        private void showKorektaFakturyViewModel()
        {
            KorektaFakturyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is KorektaFakturyViewModel) as KorektaFakturyViewModel;

            if (workspace == null)
            {
                //tworzymy nowa zakladke Wszystkie towary
                workspace = new KorektaFakturyViewModel();
                //i dodajemy ja do kolekcji zakladek
                this.Workspaces.Add(workspace);
            }
            //aktywujemy zakladke
            this.setActiveWorkspace(workspace);

        }

        private void showZamowieniaWMSViewModel()
        {
            ZamowieniaWMSViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is ZamowieniaWMSViewModel) as ZamowieniaWMSViewModel;

            if (workspace == null)
            {
                //tworzymy nowa zakladke Wszystkie towary
                workspace = new ZamowieniaWMSViewModel();
                //i dodajemy ja do kolekcji zakladek
                this.Workspaces.Add(workspace);
            }
            //aktywujemy zakladke
            this.setActiveWorkspace(workspace);

        }

        private void showRaportSprzedazyViewModel()
        {
            RaportSprzedazyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is RaportSprzedazyViewModel) as RaportSprzedazyViewModel;

            if (workspace == null)
            {
                //tworzymy nowa zakladke Wszystkie towary
                workspace = new RaportSprzedazyViewModel();
                //i dodajemy ja do kolekcji zakladek
                this.Workspaces.Add(workspace);
            }
            //aktywujemy zakladke
            this.setActiveWorkspace(workspace);

        }

        private void showRaportKontrahentowViewModel()
        {
            RaportKontrahenciViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is RaportKontrahenciViewModel) as RaportKontrahenciViewModel;

            if (workspace == null)
            {
                //tworzymy nowa zakladke Wszystkie towary
                workspace = new RaportKontrahenciViewModel();
                //i dodajemy ja do kolekcji zakladek
                this.Workspaces.Add(workspace);
            }
            //aktywujemy zakladke
            this.setActiveWorkspace(workspace);

        }
        private void showModyfikujFaktureViewModel()
        {
            ModyfikujFaktureViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is ModyfikujFaktureViewModel) as ModyfikujFaktureViewModel;

            if (workspace == null)
            {
                //tworzymy nowa zakladke Wszystkie towary
                workspace = new ModyfikujFaktureViewModel();
                //i dodajemy ja do kolekcji zakladek
                this.Workspaces.Add(workspace);
            }
            //aktywujemy zakladke
            this.setActiveWorkspace(workspace);

        }

        private void showNowyPracownikKadrViewModel()
        {
            NowyPracownikKadrViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NowyPracownikKadrViewModel) as NowyPracownikKadrViewModel;

            if (workspace == null)
            {
                //tworzymy nowa zakladke Wszystkie towary
                workspace = new NowyPracownikKadrViewModel();
                //i dodajemy ja do kolekcji zakladek
                this.Workspaces.Add(workspace);
            }
            //aktywujemy zakladke
            this.setActiveWorkspace(workspace);

        }
        private void showShowNoweZamowienieOdKlienowViewModel()
        {
            NoweZamowienieOdKlientowViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NoweZamowienieOdKlientowViewModel) as NoweZamowienieOdKlientowViewModel;

            if (workspace == null)
            {
                //tworzymy nowa zakladke Wszystkie towary
                workspace = new NoweZamowienieOdKlientowViewModel();
                //i dodajemy ja do kolekcji zakladek
                this.Workspaces.Add(workspace);
            }
            //aktywujemy zakladke
            this.setActiveWorkspace(workspace);

        }





        private void setActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }


        #endregion
     #endregion
    }
}

