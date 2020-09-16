using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Военный_округ_Final_.Dao
{
    class DataProvider
    {
        /// <summary>
        ///
        /// </summary>
            private Context.voenniy_okrugEntities context;
            
            

            public DataProvider()
            {
                this.context = new Context.voenniy_okrugEntities();

               /* this.sluzhaschiy = new Entities.Sluzhaschiy(context);
                this.podrazdelenie = new Entities.Podrazdelenie(context);
                this.obiedinenie = new Entities.Obiedinenie(context);
                this.sooruzhenie = new Entities.Sooruzhenie(context);
                this.boevayaTehnika = new Entities.BoevayaTehnika(context);
                this.transportnayaTehnika = new Entities.TransportnayaTehnika(context);*/
        }

        public string[] GetTableList() {
            string[] result = new string[7];

            result[0] = "Служащие";
            result[1] = "Подразделения";
            result[2] = "Обьединения";
            result[3] = "Сооружения";
            result[4] = "Боевая техника";
            result[5] = "Транспортная техника";
            result[6] = "Пользователи";
            
            return result;
        }


        /// <summary>
        /// Метод ищет человека с таким логином и паролем в базе, и возвращает уровень его доступа,в случае если пароль верный
        /// </summary>
        /// <param name="login">логин пользователя</param>
        /// <param name="password">пароль пользователя</param>
        /// <returns></returns>
        public int tryLogin(string login, string password)
        {
            var user = context.Users.Where(x => (x.login == login) && (x.password == password)).FirstOrDefault();

            if (user != null)
            {
                if (user.change_rights.Contains("c"))
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }

        public bool IsLoginFree(string login)
        {

            if ((context.Users.Where(x => x.login == login)).Any())
            {
                return false;
            }
            else
            {
                return true;
            }


        }

        public bool CreateUser(string login, string password)
        {

            var user = new Context.Users();
            user.login = login;
            user.password = password;
            int maxId = context.Users.Max(x => x.id);
            user.id = maxId + 1;
            user.change_rights = "r";
            context.Users.Add(user);
            context.SaveChanges();

            return true;

        }

        public List<Entities.User> GetListUser(string id, string login,int fromRow, int pageLimit)
        {

            List<Entities.User> list = new List<Entities.User>();
            var listRaw = context.Users.Where(us => ((id == "" || id == us.id.ToString()) &&
                                                                                                (login == "" || us.login == login) )).OrderBy(x => x.id).Skip(fromRow).Take(pageLimit).ToList();

            foreach (var us in listRaw)
            {
                Entities.User entity = new Entities.User();
                entity.id = us.id;
                entity.login = us.login;
                entity.password = us.password;
               

                list.Add(entity);
            }
            return list;
        }

        /// <summary>
        ///  Метод для создания, удаления и редактирования записей в таблице Пользователи
        /// </summary>
        /// <param name="newList">Список новых записей типа Пользователи</param>
        /// <param name="deletedList">Список удаляемых записей типа Пользователи</param>
        /// <param name="updatedList">Список измененных записей типа Пользователи</param>
        public void SaveChangesUser(List<Entities.User> newList, List<Entities.User> deletedList, List<Entities.User> updatedList)
        {
            // добавление записи в базу
            foreach (var us in newList)
            {
                var userEntity = new Context.Users();
                userEntity.id = context.Users.Max(x => x.id) + 1;
                userEntity.login = us.login;
                userEntity.password = us.password;
                
                context.Users.Add(userEntity);

            }

            // удаление из базы
            foreach (var us in deletedList)
            {
                var UserEntity = context.Users.Where(x => x.id == us.id).FirstOrDefault();
                
                    context.Users.Remove(UserEntity);
                


            }

            //обновление информации в базе
            foreach (var us in updatedList)
            {
                var userEntity = context.Users.FirstOrDefault(x => x.id == us.id);
                if (userEntity != null)
                {
                    userEntity.login = us.login;
                    userEntity.password = us.password;
                }
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Возвращает страницу данных по Транспортной технике, осуществляет поиск по id,названию,подразделению
        /// </summary>
        /// <param name="id">Уникальный идентификатор записи в журнале</param>
        /// <param name="tipTransportnoyTehniki">Название вида транспортной техники</param>
        /// <param name="podrazdelenieId">Подразделение,к которому относится транспортная техника</param>
        /// <param name="fromRow">Номер ряда, с которого передавать данные</param>
        /// <param name="pageLimit">Колличество строк,которые необходимо передать</param>
        /// <returns></returns>
        public List<Entities.TransportnayaTehnika> GetListTransportnayaTehnika(string id, string tipTransportnoyTehniki, string podrazdelenieId, int fromRow, int pageLimit)
         {

            List<Entities.TransportnayaTehnika> list = new List<Entities.TransportnayaTehnika>();
            var listRaw = context.Transportnaya_tehnika.Where(bt => ((id == "" || id == bt.id.ToString()) &&
                                                                                                (tipTransportnoyTehniki == "" || bt.Tip_transportnoy_tehniki.nazvanie == tipTransportnoyTehniki) &&
                                                                                                (podrazdelenieId == "" || podrazdelenieId == bt.podrazdelenie.ToString()))).OrderBy(x => x.id).Skip(fromRow).Take(pageLimit).ToList();

            foreach (var tt in listRaw)
            {
                Entities.TransportnayaTehnika entity = new Entities.TransportnayaTehnika();
                entity.id = tt.id;
                entity.tipTransportnoyTehniki = tt.Tip_transportnoy_tehniki.nazvanie;
                entity.podrazdelenieId = (tt.Podrazdelenie1 == null) ? 0 : tt.Podrazdelenie1.id;
                entity.kolichestvo = tt.kolichestvo.Value;
                entity.dopInfo = tt.dop_info;


                list.Add(entity);
            }
            return list;
        }


        /// <summary>
        ///  Метод для создания, удаления и редактирования записей в таблице Транспортная техника
        /// </summary>
        /// <param name="newList">Список новых записей типа Транспортная техника</param>
        /// <param name="deletedList">Список удаляемых записей типа Транспортная техника</param>
        /// <param name="updatedList">Список измененных записей типа Транспортная техника</param>
        public void SaveChangesTransportnayaTehnika(List<Entities.TransportnayaTehnika> newList, List<Entities.TransportnayaTehnika> deletedList, List<Entities.TransportnayaTehnika> updatedList)
        {
            // добавление записи в базу
            foreach (var tt in newList)
            {
                var transportnayaTehnikaEntity = new Context.Transportnaya_tehnika();
                transportnayaTehnikaEntity.id = context.Transportnaya_tehnika.Max(x => x.id) + 1;
                transportnayaTehnikaEntity.kolichestvo = tt.kolichestvo;
                var podrazdelenieEntity = context.Podrazdelenie.Where(x => x.id == tt.podrazdelenieId).FirstOrDefault();
                transportnayaTehnikaEntity.podrazdelenie = (podrazdelenieEntity == null) ? 0 : podrazdelenieEntity.id;
                var tipEntity = context.Tip_transportnoy_tehniki.Where(x => x.nazvanie == tt.tipTransportnoyTehniki).FirstOrDefault();
                transportnayaTehnikaEntity.tip = (tipEntity == null) ? 0 : tipEntity.id;
                
                context.Transportnaya_tehnika.Add(transportnayaTehnikaEntity);
            }

            // удаление из базы
            foreach (var tt in deletedList)
            {
                var transportnayaTehnikaEntity = context.Transportnaya_tehnika.Where(x => x.id == tt.id).FirstOrDefault();
                if (transportnayaTehnikaEntity != null)
                {
                    context.Transportnaya_tehnika.Remove(transportnayaTehnikaEntity);
                }


            }

            //обновление информации в базе
            foreach (var tt in updatedList)
            {
                var transportnayaTehnikaEntity = context.Transportnaya_tehnika.FirstOrDefault(x => x.id == tt.id);
                if (transportnayaTehnikaEntity != null)
                {
                    transportnayaTehnikaEntity.kolichestvo = tt.kolichestvo;
                    var podrazdelenieEntity = context.Podrazdelenie.Where(x => x.id == tt.podrazdelenieId).FirstOrDefault();
                    transportnayaTehnikaEntity.podrazdelenie = (podrazdelenieEntity == null) ? 0 : podrazdelenieEntity.id;
                    var tipEntity = context.Tip_transportnoy_tehniki.Where(x => x.nazvanie == tt.tipTransportnoyTehniki).FirstOrDefault();
                    transportnayaTehnikaEntity.tip = (tipEntity == null) ? 0 : tipEntity.id;

                }
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Возвращает страницу данных по Боевой технике из базы, осуществляет поиск по id,названию,подразделению
        /// </summary>
        /// <param name="id">Уникальный идетификатор записи в журнале</param>
        /// <param name="tipBoevoyTehniki">Название вида боевой техники</param>
        /// <param name="podrazdelenieId">Подразделение,к которому прикреплена боевая техника</param>
        /// <param name="fromRow">Номер ряда, с которого передавать данные</param>
        /// <param name="pageLimit">Колличество строк,которые необходимо передать</param>
        /// <returns></returns>
        public List<Entities.BoevayaTehnika> GetListBoevayaTehnika(string id, string tipBoevoyTehniki, string podrazdelenieId, int fromRow, int pageLimit)
        {
            List<Entities.BoevayaTehnika> list = new List<Entities.BoevayaTehnika>();
            var listRaw = context.Boevaya_tehnika.Where(bt => ((id == "" || id == bt.id.ToString()) && 
                                                                                                (tipBoevoyTehniki == "" || bt.Tip_boevoy_tehniki.nazvanie == tipBoevoyTehniki) &&
                                                                                                (podrazdelenieId == "" || podrazdelenieId == bt.podrazdelenie.ToString()))).OrderBy(x => x.id).Skip(fromRow).Take(pageLimit).ToList();

            foreach (var bt in listRaw)
            {
                Entities.BoevayaTehnika entity = new Entities.BoevayaTehnika();
                entity.id = bt.id;
                entity.tipBoevoyTehniki = bt.Tip_boevoy_tehniki.nazvanie;
                entity.podrazdelenieId = (bt.Podrazdelenie1 == null) ? 0 : bt.Podrazdelenie1.id;
                entity.kolichestvo = bt.kolichestvo.Value;
                entity.dopInfo = bt.dop_info;


                list.Add(entity);
            }
            return list;
        }

        /// <summary>
        ///  Метод для создания, удаления и редактирования записей в таблице Боевая техника
        /// </summary>
        /// <param name="newList">Список новых записей типа Боевая техника</param>
        /// <param name="deletedList">Список удаляемых записей типа Боевая техника</param>
        /// <param name="updatedList">Список измененных записей типа Боевая техника</param>
        public void SaveChangesBoevayaTehnika(List<Entities.BoevayaTehnika> newList, List<Entities.BoevayaTehnika> deletedList, List<Entities.BoevayaTehnika> updatedList)
        {
            // добавление записи в базу
            foreach (var bt in newList)
            {
                var boevayaTehnikaEntity = new Context.Boevaya_tehnika();
                boevayaTehnikaEntity.id = context.Boevaya_tehnika.Max(x => x.id) + 1;
                boevayaTehnikaEntity.kolichestvo = bt.kolichestvo;
                var podrazdelenieEntity = context.Podrazdelenie.Where(x => x.id == bt.podrazdelenieId).FirstOrDefault();
                boevayaTehnikaEntity.podrazdelenie = (podrazdelenieEntity == null) ? 0 : podrazdelenieEntity.id;
                var tipEntity = context.Tip_boevoy_tehniki.Where(x => x.nazvanie == bt.tipBoevoyTehniki).FirstOrDefault();
                boevayaTehnikaEntity.tip = (tipEntity == null) ? 0 : tipEntity.id;
                
                context.Boevaya_tehnika.Add(boevayaTehnikaEntity);

            }

            // удаление из базы
            foreach (var bt in deletedList)
            {
                var boevayaTehnikaEntity = context.Boevaya_tehnika.Where(x => x.id == bt.id).FirstOrDefault();
                if (boevayaTehnikaEntity != null)
                {
                    context.Boevaya_tehnika.Remove(boevayaTehnikaEntity);
                }


            }

            //обновление информации в базе
            foreach (var bt in updatedList)
            {
                var boevayaTehnikaEntity = context.Boevaya_tehnika.FirstOrDefault(x => x.id == bt.id);
                if (boevayaTehnikaEntity != null)
                {
                    boevayaTehnikaEntity.kolichestvo = bt.kolichestvo;
                    var podrazdelenieEntity = context.Podrazdelenie.Where(x => x.id == bt.podrazdelenieId).FirstOrDefault();
                    boevayaTehnikaEntity.podrazdelenie = (podrazdelenieEntity == null) ? 0 : podrazdelenieEntity.id;
                    var tipEntity = context.Tip_boevoy_tehniki.Where(x => x.nazvanie == bt.tipBoevoyTehniki).FirstOrDefault();
                    boevayaTehnikaEntity.tip = (tipEntity == null) ? 0 : tipEntity.id;

                }
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Возвращает страницу данных по списку Сооружений, осуществляет поиск по id,названию,подразделению
        /// </summary>
        /// <param name="id">Уникальный идетификатор </param>
        /// <param name="nazvanie">Название сооружения</param>
        /// <param name="podrazdelenieId">Подразделение, к которому относится сооружение</param>
        /// <param name="fromRow">Номер ряда, с которого передавать данные</param>
        /// <param name="pageLimit">Колличество строк,которые необходимо передать</param>
        /// <returns></returns>
        public List<Entities.Sooruzhenie> GetListSooruzhenie(string id, string nazvanie, string podrazdelenieId, int fromRow, int pageLimit)
              {
            List<Entities.Sooruzhenie> list = new List<Entities.Sooruzhenie>();
            var listRaw = context.Sooruzhenie.Where(so => ((id == "" || id == so.id.ToString()) &&
                                                                                        (nazvanie == "" || nazvanie == so.nazvanie.ToString()) && 
                                                                                        (podrazdelenieId == "" || podrazdelenieId == so.podrazdelenie.ToString()))).OrderBy(x => x.id).Skip(fromRow).Take(pageLimit).ToList();

            foreach (var so in listRaw)
            {
                Entities.Sooruzhenie entity = new Entities.Sooruzhenie();
                entity.id = so.id;
                entity.nazvanie = so.nazvanie;
                entity.podrazdelenieId = so.Podrazdelenie1.id;

                
                list.Add(entity);
            }

            return list;
        }


        /// <summary>
        ///  Метод для создания, удаления и редактирования записей в таблице Сооружения
        /// </summary>
        /// <param name="newList">Список новых записей типа Сооружение</param>
        /// <param name="deletedList">Список удаляемых записей типа Сооружение</param>
        /// <param name="updatedList">Список измененных записей типа Сооружение</param>
        public void SaveChangesSooruzhenie(List<Entities.Sooruzhenie> newList, List<Entities.Sooruzhenie> deletedList, List<Entities.Sooruzhenie> updatedList)
        {
            // добавление записи в базу
            foreach (var so in newList)
            {
                var sooruzhenieEntity = new Context.Sooruzhenie();
                sooruzhenieEntity.id = context.Sooruzhenie.Max(x => x.id) + 1;
                sooruzhenieEntity.nazvanie = so.nazvanie;
                var podrazdelenieEntity = context.Podrazdelenie.Where(x => x.id == so.podrazdelenieId).FirstOrDefault();
                sooruzhenieEntity.podrazdelenie = (podrazdelenieEntity == null) ? 0 : podrazdelenieEntity.id;


                context.Sooruzhenie.Add(sooruzhenieEntity);

            }

            // удаление из базы
            foreach (var so in deletedList)
            {
                var SooruzhenieEntity = context.Sooruzhenie.Where(x => x.id == so.id).FirstOrDefault();
                if (SooruzhenieEntity != null)
                {
                    context.Sooruzhenie.Remove(SooruzhenieEntity);
                }


            }

            //обновление информации в базе
            foreach (var so in updatedList)
            {
                var sooruzhenieEntity = context.Sooruzhenie.FirstOrDefault(x => x.id == so.id);
                if (sooruzhenieEntity != null)
                {
                    sooruzhenieEntity.nazvanie = so.nazvanie;
                    var podrazdelenieEntity = context.Podrazdelenie.Where(x => x.id == so.podrazdelenieId).FirstOrDefault();
                    sooruzhenieEntity.podrazdelenie = (podrazdelenieEntity == null) ? 0 : podrazdelenieEntity.id;

                }
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Возвращает страницу данных по списку Обьединений, осуществляет поиск по id,названию,типу обьединения
        /// </summary>
        /// <param name="id">Уникальный идетификатор </param>
        /// <param name="nazvanie">Название обьединения</param>
        /// <param name="tipObiedineniya">Тип обьединения(Дивизия,Бригада,Корпус)</param>
        /// <param name="fromRow">Номер ряда, с которого передавать данные</param>
        /// <param name="pageLimit">Колличество строк,которые необходимо передать</param>
        /// <returns></returns>
        public List<Entities.Obiedinenie> GetListObiedinenie(string id, string nazvanie, string tipObiedineniya, int fromRow, int pageLimit)
            {
                
                 List<Entities.Obiedinenie> list = new List<Entities.Obiedinenie>();
                var listRaw = context.Obiedinenie.Where(ob => ((id == "" || id == ob.id.ToString()) &&
                                                                                                                        (nazvanie == "" || nazvanie == ob.nazvanie.ToString()) &&
                                                                                                                        (tipObiedineniya == "" || tipObiedineniya == ob.Tip_obiedineniya.nazvanie))).OrderBy(x => x.id).Skip(fromRow).Take(pageLimit).ToList();

            foreach (var ob in listRaw)
            {
                Entities.Obiedinenie entity = new Entities.Obiedinenie();
                entity.id = ob.id;
                entity.nazvanie = ob.nazvanie;
                entity.tipObiedineniya = ob.Tip_obiedineniya.nazvanie;

                entity.sostav = String.Join(",", ob.Obiedinenie_chast.Select(x => x.chast));

                list.Add(entity);
            }


            return list;
        }


        /// <summary>
        ///  Метод для создания, удаления и редактирования записей в таблице Обьединения
        /// </summary>
        /// <param name="newList">Список новых записей типа Обьединение</param>
        /// <param name="deletedList">Список удаляемых записей типа Обьединение</param>
        /// <param name="updatedList">Список измененных записей типа Обьединение</param>
        public void SaveChangesObiedinenie(List<Entities.Obiedinenie> newList, List<Entities.Obiedinenie> deletedList, List<Entities.Obiedinenie> updatedList)
        {
            // добавление записи в базу
            foreach (var ob in newList)
            {
                var obiedinenieEntity = new Context.Obiedinenie();
                obiedinenieEntity.id = context.Obiedinenie.Max(x => x.id) + 1;
                obiedinenieEntity.nazvanie = ob.nazvanie;
                var tipObiedineniyaniyaEntity = context.Tip_obiedineniya.Where(x => x.nazvanie == ob.tipObiedineniya).FirstOrDefault();
                obiedinenieEntity.tip = (tipObiedineniyaniyaEntity == null) ? 0 : tipObiedineniyaniyaEntity.id;


                context.Obiedinenie.Add(obiedinenieEntity);

            }

            // удаление из базы
            foreach (var ob in deletedList)
            {
                var obiedinenieEntity = context.Obiedinenie.Where(x => x.id == ob.id).FirstOrDefault();
                if (obiedinenieEntity != null)
                {
                    context.Obiedinenie.Remove(obiedinenieEntity);
                }


            }

            //обновление информации в базе
            foreach (var ob in updatedList)
            {
                var obiedinenieEntity = context.Obiedinenie.FirstOrDefault(x => x.id == ob.id);
                if (obiedinenieEntity != null)
                {
                    obiedinenieEntity.nazvanie = ob.nazvanie;
                    var tipObiedineniyaniyaEntity = context.Tip_obiedineniya.Where(x => x.nazvanie == ob.tipObiedineniya).FirstOrDefault();
                    obiedinenieEntity.tip = (tipObiedineniyaniyaEntity == null) ? 0 : tipObiedineniyaniyaEntity.id;

                }
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Возвращает страницу данных по списку Подразделений, осуществляет поиск по id,названию,типу подразделения
        /// </summary>
        /// <param name="id">Уникальный идетификатор </param>
        /// <param name="nazvanie">Название подразделения</param>
        /// <param name="tipPodrazdeleniya">Тип подразделения(Взвод,Рота,Часть)</param>
        /// <param name="fromRow">Номер ряда, с которого передавать данные</param>
        /// <param name="pageLimit">Колличество строк,которые необходимо передать</param>
        /// <returns></returns>
        public List<Entities.Podrazdelenie> GetListPodrazdelenie(string id, string nazvanie, string tipPodrazdeleniya, int fromRow, int pageLimit)
          {
            List<Entities.Podrazdelenie> list = new List<Entities.Podrazdelenie>();
            var listRaw = context.Podrazdelenie.Where(pd => ((id == "" || id == pd.id.ToString()) &&
                                                                                               (nazvanie == "" || nazvanie == pd.nazvanie) &&
                                                                                               (tipPodrazdeleniya == "" || tipPodrazdeleniya == pd.Tip_podrazdeleniya.nazvanie))).OrderBy(x => x.id).Skip(fromRow).Take(pageLimit);

            foreach (var pd in listRaw)
            {
                Entities.Podrazdelenie entity = new Entities.Podrazdelenie();
                entity.id = pd.id;
                entity.nazvanie = pd.nazvanie;
                entity.tipPodrazdeleniya = pd.Tip_podrazdeleniya.nazvanie;
                entity.komandir = (pd.komandir == 0) ? 0 : pd.Sluzhashchie.id;
                entity.location = pd.location;
                
                list.Add(entity);
            }


            return list;
        }

        /// <summary>
        ///  Метод для создания, удаления и редактирования записей в таблице Подразделения
        /// </summary>
        /// <param name="newList">Список новых записей типа Подразделение</param>
        /// <param name="deletedList">Список удаляемых записей типа Подразделение</param>
        /// <param name="updatedList">Список измененных записей типа Подразделение</param>
        public void SaveChangesPodrazdelenie(List<Entities.Podrazdelenie> newList, List<Entities.Podrazdelenie> deletedList, List<Entities.Podrazdelenie> updatedList)
        {
            // добавление записи в базу
            foreach (var pd in newList)
            {
                var podrazdelenieEntity = new Context.Podrazdelenie();
                podrazdelenieEntity.id = context.Podrazdelenie.Max(x => x.id) + 1;
                podrazdelenieEntity.nazvanie = pd.nazvanie;
                podrazdelenieEntity.location = pd.location;
                var starshiyEntity = context.Podrazdelenie.Where(x => x.id == pd.idStarshegoPodrazdeleniya).FirstOrDefault();
                podrazdelenieEntity.id_starshego = (starshiyEntity == null) ? 0 : starshiyEntity.id;
                var komandirEntity = context.Sluzhashchie.Where(x => x.id == pd.komandir).FirstOrDefault();
                podrazdelenieEntity.komandir = (komandirEntity == null) ? 0 : komandirEntity.id;
                var tipPodrazdeleniyaEntity = context.Tip_podrazdeleniya.Where(x => x.nazvanie == pd.tipPodrazdeleniya).FirstOrDefault();
                podrazdelenieEntity.tip = (tipPodrazdeleniyaEntity == null) ? 0 : tipPodrazdeleniyaEntity.id;


                context.Podrazdelenie.Add(podrazdelenieEntity);
                
            }

            // удаление из базы
            foreach (var pd in deletedList)
            {
                var podrazdelenieEntity = context.Podrazdelenie.Where(x => x.id == pd.id).FirstOrDefault();
                if (podrazdelenieEntity != null)
                {
                    context.Podrazdelenie.Remove(podrazdelenieEntity);
                }
            }

            //обновление информации в базе
            foreach (var pd in updatedList)
            {
                var podrazdelenieEntity = context.Podrazdelenie.FirstOrDefault(x => x.id == pd.id);
                if (podrazdelenieEntity != null)
                {
                    podrazdelenieEntity.nazvanie = pd.nazvanie;
                    podrazdelenieEntity.location = pd.location;
                    var starshiyEntity = context.Podrazdelenie.Where(x => x.id == pd.idStarshegoPodrazdeleniya).FirstOrDefault();
                    podrazdelenieEntity.id_starshego = (starshiyEntity == null) ? 0 : starshiyEntity.id;
                    var komandirEntity = context.Sluzhashchie.Where(x => x.id == pd.komandir).FirstOrDefault();
                    podrazdelenieEntity.komandir = (komandirEntity == null) ? 0 : komandirEntity.id;
                    var tipPodrazdeleniyaEntity = context.Tip_podrazdeleniya.Where(x => x.nazvanie == pd.tipPodrazdeleniya).FirstOrDefault();
                    podrazdelenieEntity.tip = (tipPodrazdeleniyaEntity == null) ? 0 : tipPodrazdeleniyaEntity.id;

                }
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Возвращает страницу данных по списку Служащих, осуществляет поиск по id, ФИО
        /// </summary>
        /// <param name="id">Уникальный идентификатор служащего</param>
        /// <param name="imya">Имя служащего</param>
        /// <param name="otchestvo">Отчество служащего</param>
        /// <param name="familiya">Фамилия служащего</param>
        /// <param name="fromRow">Номер ряда, с которого передавать данные</param>
        /// <param name="pageLimit">Колличество строк,которые необходимо передать</param>
        /// <returns></returns>
        public List<Entities.Sluzhaschiy> GetListSluzhaschie(string id, string imya, string otchestvo, string familiya, int fromRow, int pageLimit)
        {
            List<Entities.Sluzhaschiy> list = new List<Entities.Sluzhaschiy>();
            var listRaw = context.Sluzhashchie.Where(sl => ((id == "" || id == sl.id.ToString()) &&
                                                                                               (imya == "" || imya == sl.imya) &&
                                                                                               (otchestvo == "" || otchestvo == sl.otchestvo) &&
                                                                                               (familiya == "" || familiya == sl.familiya))).OrderBy(x => x.id).Skip(fromRow).Take(pageLimit);

            foreach (var sl in listRaw) {
                Entities.Sluzhaschiy entity = new Entities.Sluzhaschiy();
                entity.id = sl.id;
                entity.imya = sl.imya;
                entity.otchestvo = sl.otchestvo;
                entity.familiya = sl.familiya;
                entity.idStarshego = (sl.Sluzhashchie2 == null) ? 0 : sl.Sluzhashchie2.id;
                entity.zvanie = ((sl.Mladshiy_sostav == null ) ? "" : sl.Mladshiy_sostav.Mladshiy_zvanie.zvanie) + 
                                                           ( (sl.Starshiy_sostav == null ) ? "" : sl.Starshiy_sostav.Starshiy_zvanie.zvanie) ;
                                                                                              
                list.Add(entity);
            }
        
            
         return list;
         }


        /// <summary>
        ///  Метод для создания, удаления и редактирования записей в таблицах Служащие,Старший состав и Младший состав
        /// </summary>
        /// <param name="newList">Список новых записей типа Служащий</param>
        /// <param name="deletedList">Список удаляемых записей типа Служащий</param>
        /// <param name="updatedList">Список измененных записей типа Служащий</param>
        public void SaveChangesSluzhaschie(List<Entities.Sluzhaschiy> newList, List<Entities.Sluzhaschiy> deletedList, List<Entities.Sluzhaschiy> updatedList)
        {
            // добавление записи в базу
            foreach (var sl in newList)
            {
                var sluzhaschiyEntity = new Context.Sluzhashchie();
                sluzhaschiyEntity.id = context.Sluzhashchie.Max(x => x.id) + 1;
                sluzhaschiyEntity.imya = sl.imya;
                sluzhaschiyEntity.otchestvo = sl.otchestvo;
                sluzhaschiyEntity.familiya = sl.familiya;
                var starshiyEntity = context.Sluzhashchie.Where(x => x.id == sl.idStarshego).FirstOrDefault();
                sluzhaschiyEntity.id_starshego = (starshiyEntity == null) ? 0 : starshiyEntity.id;

                
                context.Sluzhashchie.Add(sluzhaschiyEntity);

                var starshiyZvanie = context.Starshiy_zvanie.Where(x => x.zvanie == sl.zvanie).FirstOrDefault();
                if (starshiyZvanie != null)
                {
                    var starshiySostavEntity = new Context.Starshiy_sostav();
                    starshiySostavEntity.Sluzhashchie = sluzhaschiyEntity;
                    starshiySostavEntity.zvanie = starshiyZvanie.id;

                    context.Starshiy_sostav.Add(starshiySostavEntity);
                }
                var mladshiyZvanie = context.Mladshiy_zvanie.Where(x => x.zvanie == sl.zvanie).FirstOrDefault();
                if (mladshiyZvanie != null)
                {
                    var mladshiySostavEntity = new Context.Mladshiy_sostav();
                    mladshiySostavEntity.Sluzhashchie = sluzhaschiyEntity;
                    mladshiySostavEntity.zvanie = mladshiyZvanie.id;

                    context.Mladshiy_sostav.Add(mladshiySostavEntity);
                }               
            }

            // удаление из базы
            foreach (var sl in deletedList)
            {
                var sluzhaschiyEntity = context.Sluzhashchie.Where(x => x.id == sl.id).FirstOrDefault();
                if (sluzhaschiyEntity != null)
                {
                    context.Sluzhashchie.Remove(sluzhaschiyEntity);
                }
            }

            //обновление информации в базе
            foreach (var sl in updatedList)
            {
                var sluzhaschiyEntity = context.Sluzhashchie.FirstOrDefault(x => x.id == sl.id);
                if (sluzhaschiyEntity != null)
                {
                    sluzhaschiyEntity.imya = sl.imya;
                    sluzhaschiyEntity.otchestvo = sl.otchestvo;
                    sluzhaschiyEntity.familiya = sl.familiya;

                    var starshiyEntity = context.Sluzhashchie.Where(x => x.id == sl.idStarshego).FirstOrDefault();
                    sluzhaschiyEntity.id_starshego = (starshiyEntity == null) ? 0 : starshiyEntity.id;
                    
                }
            }
            context.SaveChanges();
        }


        /// <summary>
        /// Выполнение свободного SQL-запроса в базе
        /// </summary>
        /// <param name="command_string">Строка запроса</param>
        /// <returns></returns>
        public List<string[]> ExecuteCommand(string command_string)
            {
                try
                {
                    List<string[]> data = new List<string[]>();

                    string separator = ",";
                    int argumentNumber = (command_string.Length - command_string.Replace(separator, "").Length) / separator.Length;

                    var result = new Context.voenniy_okrugEntities().Database.SqlQuery<string[][]>(command_string);


                    foreach (var row in result)
                    {
                        data.Add(new string[argumentNumber]);
                        for (int i = 0; i < argumentNumber; i++)
                        {
                            data[data.Count - 1][i] = row[i].ToString();
                        }
                    }
                    return data;

                }
                catch (Exception ex)
                {
                    List<String[]> data = new List<string[]>();
                    data.Add(new string[1]);
                    data[data.Count - 1][0] = ex.Message.ToString();
                    return data;
                }

            }

        }
    }
