using Microsoft.EntityFrameworkCore;
namespace tpmodul10_1302220080
{
    public class MahasiswaDb : DbContext
    {
        public MahasiswaDb(DbContextOptions<MahasiswaDb> options) : base(options) { }
        public DbSet<Mahasiswa> Mahasiswas => Set<Mahasiswa>();
    }
}
