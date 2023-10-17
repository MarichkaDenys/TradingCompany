using AutoMapper;

namespace DAL.Concreate
{
    public class PersonDal : IPersonDal, IDisposable
    {
        private readonly TradingCompanyContext _dbContext;
        private readonly IMapper _mapper;
        public PersonDal(string connectionString, IMapper mapper)
        {
            _dbContext = new TradingCompanyContext(connectionString);
            _mapper = mapper;
        }

        public void DeleteById(int id)
        {
            var personToDelete = _dbContext.People.Find(id);

            if (personToDelete != null)
            {
                _dbContext.People.Remove(personToDelete);
                _dbContext.SaveChanges();
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public List<Person> GetAll()
        {
            List<Person> people = _dbContext.People.ToList();
            return _mapper.Map<List<Person>>(people);
        }

        public Person GetById(int id)
        {
            var person = _dbContext.People.Find(id);
            return _mapper.Map<Person>(person);
        }

        public Person Insert(Person person)
        {
            person.Date = DateTime.Now;
            var newPerson = _mapper.Map<Person>(person);
            _dbContext.People.Add(newPerson);
            _dbContext.SaveChanges();
            return _mapper.Map<Person>(newPerson);
        }

        public Person Update(Person person)
        {
            var existingPerson = _dbContext.People.Find(person.PersonId);

            if (existingPerson != null)
            {
                existingPerson.RoleId = person.RoleId;
                existingPerson.FirstName = person.FirstName; 
                existingPerson.LastName = person.LastName;
                existingPerson.Login = person.Login;
                existingPerson.Password = person.Password;
                existingPerson.Date = DateTime.Now;


                _dbContext.SaveChanges();
                return _mapper.Map<Person>(existingPerson);
            }

            throw new InvalidOperationException($"Person with ID {person.PersonId} not found.");
        }
    }
}
