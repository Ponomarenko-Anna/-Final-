using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Военный_округ_Final_
{
    public partial class Form1 : Form
    {
        private int pageLimit = 15;
        private Dao.DataProvider control;

        private List<Dao.Entities.Sluzhaschiy> slCurrentList;
        private List<Dao.Entities.Podrazdelenie> pdCurrentList;
        private List<Dao.Entities.Obiedinenie> obCurrentList;
        private List<Dao.Entities.Sooruzhenie> soCurrentList;
        private List<Dao.Entities.BoevayaTehnika> btCurrentList;
        private List<Dao.Entities.TransportnayaTehnika> ttCurrentList;
        private List<Dao.Entities.User> usCurrentList;

        private List<Dao.Entities.Sluzhaschiy> slCopyList;
        private List<Dao.Entities.Podrazdelenie> pdCopyList;
        private List<Dao.Entities.Obiedinenie> obCopyList;
        private List<Dao.Entities.Sooruzhenie> soCopyList;
        private List<Dao.Entities.BoevayaTehnika> btCopyList;
        private List<Dao.Entities.TransportnayaTehnika> ttCopyList;
        private List<Dao.Entities.User> usCopyList;

        public Form1()
        {
            
            control = new Dao.DataProvider();
            InitializeComponent();
            LoadCbTables();
            lblPage.Text = "1";

            cbTable.SelectedIndex = 0;
            btnList_Click(this, null);
            //LoadSluzhaschie(1);


        }

        void LoadCbTables() {
            string[] tableList = control.GetTableList();

            foreach (string s in tableList) {
                cbTable.Items.Add(s);
            }
        }

        void LoadSluzhaschie(int page) {
            slCurrentList = control.GetListSluzhaschie("","","","", page*this.pageLimit , pageLimit);
            slCopyList = control.GetListSluzhaschie("", "", "", "", page * this.pageLimit, pageLimit);

            if (!slCurrentList.Any())
            {
                MessageBox.Show("Больше нет страниц");
                lblPageDecrease();
                return;
            }
            // передаю в datagridview список товаров          
            dgv.DataSource = new BindingList<Dao.Entities.Sluzhaschiy>(slCurrentList); ;
        }

        void SaveChangesSluzhaschie() {
            // новые записи (это те, у которых Id = 0)
            var newRows = slCurrentList.Where(x => x.id == 0).ToList();

            // удалённые записи (есть в первоначальном списке, но отсутствуют в отредактированном)
            var deletedRows = slCopyList.Where(x => !slCurrentList.Any(y => y.id == x.id) && x.id != 0).ToList();

            // обновлённые записи
            var updatedRows = slCurrentList.Where(x => slCopyList.Any(y => y.id == x.id && (y.imya != x.imya || 
                                                                                                                                               y.otchestvo != x.otchestvo ||
                                                                                                                                               y.familiya != x.familiya ||
                                                                                                                                               y.idStarshego != x.idStarshego ||
                                                                                                                                               y.zvanie != x.zvanie ||
                                                                                                                                               y.specialnost != x.specialnost))).ToList();

            // применяю изменения к базе данных
            try
            {
                control.SaveChangesSluzhaschie(newRows, deletedRows, updatedRows);
                MessageBox.Show("Изменения сохранены");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.InnerException.InnerException.Message);
            }
        }

        void LoadPodrazdelenie(int page)
        {
            pdCurrentList = new Dao.DataProvider().GetListPodrazdelenie("", "", "",  page * this.pageLimit, pageLimit);
            pdCopyList = new Dao.DataProvider().GetListPodrazdelenie("", "", "", page * this.pageLimit, pageLimit);
            if (!pdCurrentList.Any())
            {
                MessageBox.Show("Больше нет страниц");
                lblPageDecrease();
                return;
            }
            dgv.DataSource = new BindingList<Dao.Entities.Podrazdelenie>(pdCurrentList); ;
        }

        void SaveChangesPodrazdelenie()
        {
            // новые записи (это те, у которых Id = 0)
            var newRows = pdCurrentList.Where(x => x.id == 0).ToList();

            // удалённые записи (есть в первоначальном списке, но отсутствуют в отредактированном)
            var deletedRows = pdCopyList.Where(x => !pdCurrentList.Any(y => y.id == x.id) && x.id != 0).ToList();

            // обновлённые записи
            var updatedRows = pdCurrentList.Where(x => pdCopyList.Any(y => y.id == x.id && (y.tipPodrazdeleniya != x.tipPodrazdeleniya ||
                                                                                                                                               y.nazvanie != x.nazvanie ||
                                                                                                                                               y.idStarshegoPodrazdeleniya != x.idStarshegoPodrazdeleniya ||
                                                                                                                                               y.komandir != x.komandir ||
                                                                                                                                               y.location != x.location))).ToList();

            // применяю изменения к базе данных
            try
            {
                control.SaveChangesPodrazdelenie(newRows, deletedRows, updatedRows);
                MessageBox.Show("Изменения сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message);
            }
        }

        void LoadObiedinenie(int page)
        {
            obCurrentList = new Dao.DataProvider().GetListObiedinenie("", "", "", page * this.pageLimit, pageLimit);
            obCopyList = new Dao.DataProvider().GetListObiedinenie("", "", "", page * this.pageLimit, pageLimit);
            if (!obCurrentList.Any())
            {
                MessageBox.Show("Больше нет страниц");
                lblPageDecrease();
                return;
            }
            dgv.DataSource = new BindingList<Dao.Entities.Obiedinenie>(obCurrentList); ;

        }

        void SaveChangesObiedinenie()
        {
            // новые записи (это те, у которых Id = 0)
            var newRows = obCurrentList.Where(x => x.id == 0).ToList();

            // удалённые записи (есть в первоначальном списке, но отсутствуют в отредактированном)
            var deletedRows = obCopyList.Where(x => !obCurrentList.Any(y => y.id == x.id) && x.id != 0).ToList();

            // обновлённые записи
            var updatedRows = obCurrentList.Where(x => obCopyList.Any(y => y.id == x.id && (y.tipObiedineniya != x.tipObiedineniya ||
                                                                                                                                               y.nazvanie != x.nazvanie ||
                                                                                                                                               y.sostav != x.sostav))).ToList();

            // применяю изменения к базе данных
            try
            {
                control.SaveChangesObiedinenie(newRows, deletedRows, updatedRows);
                MessageBox.Show("Изменения сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message);
            }
        }


        void LoadSooruzhenie(int page)
        {
            soCurrentList = new Dao.DataProvider().GetListSooruzhenie("", "", "", page * this.pageLimit, pageLimit);
            soCopyList = new Dao.DataProvider().GetListSooruzhenie("", "", "", page * this.pageLimit, pageLimit);
            if (!soCurrentList.Any())
            {
                MessageBox.Show("Больше нет страниц");
                lblPageDecrease();
                return;
            }
            dgv.DataSource = new BindingList<Dao.Entities.Sooruzhenie>(soCurrentList); ;

        }

        void SaveChangesSooruzhenie()
        {
            // новые записи (это те, у которых Id = 0)
            var newRows = soCurrentList.Where(x => x.id == 0).ToList();

            // удалённые записи (есть в первоначальном списке, но отсутствуют в отредактированном)
            var deletedRows = soCopyList.Where(x => !soCurrentList.Any(y => y.id == x.id) && x.id != 0).ToList();

            // обновлённые записи
            var updatedRows = soCurrentList.Where(x => soCopyList.Any(y => y.id == x.id && (y.podrazdelenieId != x.podrazdelenieId ||
                                                                                                                                               y.nazvanie != x.nazvanie))).ToList();

            // применяю изменения к базе данных
            try
            {
                control.SaveChangesSooruzhenie(newRows, deletedRows, updatedRows);
                MessageBox.Show("Изменения сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message);
            }
        }

        void LoadBoevayaTehnika(int page)
        {
            btCurrentList = new Dao.DataProvider().GetListBoevayaTehnika("", "", "", page * this.pageLimit, pageLimit);
            btCopyList = new Dao.DataProvider().GetListBoevayaTehnika("", "", "", page * this.pageLimit, pageLimit);
            if (!btCurrentList.Any())
            {
                MessageBox.Show("Больше нет страниц");
                lblPageDecrease();
                return;
            }
            dgv.DataSource = new BindingList<Dao.Entities.BoevayaTehnika>(btCurrentList); ;
        }

        void SaveChangesBoevayaTehnika()
        {
            // новые записи (это те, у которых Id = 0)
            var newRows = btCurrentList.Where(x => x.id == 0).ToList();

            // удалённые записи (есть в первоначальном списке, но отсутствуют в отредактированном)
            var deletedRows = btCopyList.Where(x => !btCurrentList.Any(y => y.id == x.id) && x.id != 0).ToList();

            // обновлённые записи
            var updatedRows = btCurrentList.Where(x => btCopyList.Any(y => y.id == x.id && (y.tipBoevoyTehniki != x.tipBoevoyTehniki ||
                                                                                                                                               y.podrazdelenieId != x.podrazdelenieId ||
                                                                                                                                               y.kolichestvo != x.kolichestvo ||
                                                                                                                                               y.dopInfo != x.dopInfo))).ToList();

            // применяю изменения к базе данных
            try
            {
                control.SaveChangesBoevayaTehnika(newRows, deletedRows, updatedRows);
                MessageBox.Show("Изменения сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message);
            }
        }

        void LoadTransportnayaTehnika(int page)
        {
            ttCurrentList = new Dao.DataProvider().GetListTransportnayaTehnika("", "", "", page * this.pageLimit, pageLimit);
            ttCopyList = new Dao.DataProvider().GetListTransportnayaTehnika("", "", "", page * this.pageLimit, pageLimit);
            if (!ttCurrentList.Any())
            {
                MessageBox.Show("Больше нет страниц");
                lblPageDecrease();
                return;
            }
            dgv.DataSource = new BindingList<Dao.Entities.TransportnayaTehnika>(ttCurrentList); ;
        }

        void SaveChangesTransportnayaTehnika()
        {
            // новые записи (это те, у которых Id = 0)
            var newRows = ttCurrentList.Where(x => x.id == 0).ToList();
            
            // удалённые записи (есть в первоначальном списке, но отсутствуют в отредактированном)
            var deletedRows = ttCopyList.Where(x => !ttCurrentList.Any(y => y.id == x.id) && x.id != 0).ToList();

            // обновлённые записи
            var updatedRows = ttCurrentList.Where(x => ttCopyList.Any(y => y.id == x.id && (y.tipTransportnoyTehniki != x.tipTransportnoyTehniki ||
                                                                                                                                               y.podrazdelenieId != x.podrazdelenieId ||
                                                                                                                                               y.kolichestvo != x.kolichestvo ||
                                                                                                                                               y.dopInfo != x.dopInfo))).ToList();

            // применяю изменения к базе данных
            try
            {
                control.SaveChangesTransportnayaTehnika(newRows, deletedRows, updatedRows);
                MessageBox.Show("Изменения сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message);
            }
        }

        void LoadUser(int page)
        {
            usCurrentList = new Dao.DataProvider().GetListUser("", "", page * this.pageLimit, pageLimit);
            usCopyList = new Dao.DataProvider().GetListUser("", "", page * this.pageLimit, pageLimit);
            if (!usCurrentList.Any())
            {
                MessageBox.Show("Больше нет страниц");
                lblPageDecrease();
                return;
            }
            dgv.DataSource = new BindingList<Dao.Entities.User>(usCurrentList); ;
        }

        void SaveChangesUser()
        {
            // новые записи (это те, у которых Id = 0)
            var newRows = usCurrentList.Where(x => x.id == 0).ToList();

            // удалённые записи (есть в первоначальном списке, но отсутствуют в отредактированном)
            var deletedRows = usCopyList.Where(x => !usCurrentList.Any(y => y.id == x.id) && x.id != 0 ).ToList();

            // обновлённые записи
            var updatedRows = usCurrentList.Where(x => usCopyList.Any(y => y.id == x.id && (y.login != x.login ||
                                                                                                                                               y.password != x.password ||
                                                                                                                                               y.changeRights != x.changeRights))).ToList();

            // применяю изменения к базе данных
            try
            {
                control.SaveChangesUser(newRows, deletedRows, updatedRows);
                MessageBox.Show("Изменения сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message);
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            lblPage.Text = "1";
            LoadData(cbTable.Text, int.Parse(lblPage.Text));          
        }

        private void LoadData(string table, int page) {
            page--;
           
            switch (table) {
                case "Служащие": {
                        LoadSluzhaschie(page);
                        break;
                    };
                case "Подразделения": {
                        LoadPodrazdelenie(page);
                        break;
                    };
                case "Обьединения": {
                        LoadObiedinenie(page);
                        break;
                    };
                case "Сооружения": {
                        LoadSooruzhenie(page);
                        break;
                    };
                case "Боевая техника": {
                        LoadBoevayaTehnika(page);
                        break;
                    };
                case "Транспортная техника": {
                        LoadTransportnayaTehnika(page);
                        break;
                    };
                case "Пользователи":
                    {
                        LoadUser(page);
                        break;
                    };

        }

        }

        private void SaveChanges(string table)
        {

            switch (table)
            {
                case "Служащие":
                    {
                        SaveChangesSluzhaschie();
                        break;
                    };
                case "Подразделения":
                    {
                        SaveChangesPodrazdelenie();
                        break;
                    };
                case "Обьединения":
                    {
                        SaveChangesObiedinenie();
                        break;
                    };
                case "Сооружения":
                    {
                        SaveChangesSooruzhenie();
                        break;
                    };
                case "Боевая техника":
                    {
                        SaveChangesBoevayaTehnika();
                        break;
                    };
                case "Транспортная техника":
                    {
                        SaveChangesTransportnayaTehnika();
                        break;
                    };
                case "Пользователи":
                    {
                        SaveChangesUser();
                        break;
                    };

            }

        }

        private void lblPageDecrease() {
            lblPage.Text = (int.Parse(lblPage.Text) - 1).ToString();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            lblPage.Text = (int.Parse(lblPage.Text) + 1).ToString();
            LoadData(cbTable.Text, int.Parse(lblPage.Text) );
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblPage.Text) <= 1)
            {
                MessageBox.Show("Больше нет страниц");
                return;
            }
            lblPageDecrease();
            LoadData(cbTable.Text, int.Parse(lblPage.Text));
        }

        private void cbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnList_Click(this, null);
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            SaveChanges(cbTable.Text);
        }
    }
}
