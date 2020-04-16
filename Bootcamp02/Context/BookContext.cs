using Bootcamp02.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp02.Context
{
    public class BookContext
    {
        

        public List<BookEntity> Books { get; set; }

        public BookContext()
        {
            Books = new List<BookEntity>
            {
                new BookEntity{
                    Id=1,
                    Author="Sebahattin Ali",
                    Name="Kuyucaklı Yusuf",
                    Publisher="Yapıkredi Yayınları"
                },
                new BookEntity{
                    Id=2,
                    Name="Momo",
                    Publisher="Kırmızı Kedi Yayınları",
                    Author="Michael Ende"
                },
                new BookEntity{
                    Id=3,
                    Name="1984",
                    Publisher="Can Yayınları",
                    Author="George Orwell"
                }
            };
        }
    }
}
