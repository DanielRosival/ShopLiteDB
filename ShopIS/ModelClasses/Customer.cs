using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopIS.ModelClasses
{
    /// <summary>
    /// Modelova/Vzorova trieda pre pouzitie s LiteDB
    /// </summary>
    public class Customer
    {
        [BsonId]    // - toto je takzvany dekorator, mozeme nim urcovat spravanie property, napriklad tento dekorator hovori, ze v tejto classe 
                    // je property Id idckom v nasej databaze, teraz to je ale zbytocne, nakolko mame vyslovene property ID, ale keby sme 
                    // chceli pouzit ako ID nejaky iny nazov napr. Zakaznik. Existuje mnoho inych LiteDB ma napriklad [BsonIgnore] este a rozne ine
                    // aj .NET ma toho vela, staci pohladat
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
