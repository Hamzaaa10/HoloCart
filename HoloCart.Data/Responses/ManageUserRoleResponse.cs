namespace HoloCart.Data.Responses
{
    public class ManageUserRoleResponse
    {
        public int UserId { get; set; }
        public List<Role> Roles { get; set; }
    }

    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasRole { get; set; }
    }
}
