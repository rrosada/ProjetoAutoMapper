using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoAutoMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<teste> list = new List<teste>
            {
                new teste{ id = 1, nome = "eee", date = 1569453513 },
                new teste{ id = 2, nome = "zzz", date = 1569453514 },
                new teste{ id = 3, nome = "qqq", date = 1569453515 },
                new teste{ id = 4, nome = "rrr", date = 1569453516 }
            };

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<teste, teste2>()
                   .ForMember(destination => destination.dateformart,
              map => map.MapFrom(source => GetDateTime(source.date)));               
            });
            IMapper mapper = configuration.CreateMapper();
            List<teste2> listDest = mapper.Map<List<teste>, List<teste2>>(list);

            Console.ReadLine();
        }
        
        public static String GetDateTime(int value)
        {
            //return value.ToString("yyyyMMddHHmmssffff");

            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

            // Add the timestamp (number of seconds since the Epoch) to be converted
            dateTime = dateTime.AddSeconds(value);

            return dateTime.ToString();
        }

    }

    class teste
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int date { get; set; }
       
    }

    class teste2
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int date { get; set; }
        public string dateformart { get; set; }
    }
}
