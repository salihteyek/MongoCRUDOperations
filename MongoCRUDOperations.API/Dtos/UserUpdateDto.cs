namespace MongoCRUDOperations.API.Dtos
{
    public class UserUpdateDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> PhoneNumbers { get; set; }
    }
}
