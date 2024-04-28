namespace tpmodul10_1302220080
{
    public class Mahasiswa
    {
        public string nama { get; set; }
        public string nim { get; set; }
        public Mahasiswa(string nama, string nim)
        {
            this.nama = nama;
            this.nim = nim;
        }
        public String getNama(string nama)
        {
            return this.nama;
        }
        public String getNim()
        {
            return this.nim;
        }
    }
}
