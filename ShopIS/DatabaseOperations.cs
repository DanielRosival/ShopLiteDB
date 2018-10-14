using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using ShopIS.ModelClasses;

namespace ShopIS
{
    public class DatabaseOperations
    {   
        //Spravim si takuto metodku, lebo chcem pouzivat using(vysvetleny nizsie), aby som to vzdy nemusel vypisovat. 
        //Spravil som to ako genericku vlastnu genericku metodu, ktora vracia tu LiteCollection toho typu. Genericke metody funguju skoro tak isto ako v c++.
        public LiteCollection<T> GetCollection<T>(string name)
        {
            //Pri pouzivani databazy, budeme pouzivat using. To sa nam postara o to aby sa zavolal takzvany finally blok - v c++ sme mali try{}catch{},
            //C# pridava este tretiu vec a to je finally{} - tento blok sa vzdy spusti, aj ked nam to spadne do catchu, aj ked vsetko prebehne v poriadku.
            //Je to na to, ze tam sa zatvoria tzv. "externe zdroje", v nasom pripade teraz databaza, ktora je v externom subore. Aj ked pracujeme so suborom, na konci
            //sme vzdy volali Close() na ten subor. 
            //Dalsia vec, po ukonceni posledneho prikazu tohto bloku sa zavola garbage collector a precisti pamet a zaniknu vsetky "premenne", ktore sme tu definovali
            //a uvolni sa pamet. Napriklad pri pouziti LiteDB nacitavame celu hromadu dat (to GetCollection) nam vrati zoznam vsetkeho a ulozi sa nam to niekde,
            //a ked to dopouzivame hodilo by sa nam zavolat nieco ako delete c++ a toto spravi za nas garbage collector po skonceni using bloku. Garbage collector sa volava
            //v pravidelnych intervaloch, a po skonceni blokov kodu (aj metody...) sa mi zda, ale neviem ci to je tak na 100%.
            //
            //Premennu ktoru budeme returnovat si musime zadefinovat pred usingom, keby sme mali definiciu vnutri, tak nam to zanikne po skonceni.
            //
            //ConfigurationManager - treba si pridat !using System.Configuration;! a takisto referenciu. To sa spravi tak, ze kliknete pravym tlacitkom na
            //References a tam vyhladate System.Configuration a zaskrtnente. Tymto sposobom vieme pristupovat k hodnotam z App.config - je to subor v projekte,
            //vzdy tam je. Sluzi na to, ze tam si viete zadefinovat nejake hodnoty, ktora sa daju nastavit aj po instalacii programu na iny pocitac, ked si chcete nieco
            //nakonfigurovat a nemusite chodit do kodu. Tento subor zostava normalny aj po kompilacii a po instalacii skompilovanych suborov je normalne pristupny.
            //V beznej praxy sa tam dava aj tzv. ConnectionString na databazu (adresa serveru atd....) u nas teraz meno/cesta k suboru.
            LiteCollection<T> collection;
            using (var db = new LiteDatabase(ConfigurationManager.AppSettings["ConnectionString"]))
            {                
                collection = db.GetCollection<T>(name);
            }
            return collection;
        }

        //spravim si aj genericku metodu na insertovanie, tiez nech to nemusim vsade pisat,
        //ked volate metodu a date na druhe miesto objekt, tak nemusite pisat objekt do <>.
        public void InsertObject<T>(string name, T objToInsert)
        {
            var objects = GetCollection<T>(name);
            objects.Insert(objToInsert);
        }        

        public void DeleteObject<T>(string name, int id)
        {
            var objects = GetCollection<T>(name);
            objects.Delete(new BsonValue(id));
        }
    }
}
