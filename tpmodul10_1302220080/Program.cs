using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tpmodul10_1302220080;
namespace tpmodul10_1302220080
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var mahasiswaList = new List<Mahasiswa>
{
            new Mahasiswa("Nabiel Ascar Mochammad", "1302220080"),
            new Mahasiswa("Fauzan Arrizqy Putra", "1302220004"),
            new Mahasiswa("Wildan Hadi Fernando", "1302223012"),
            new Mahasiswa("Muhammad Izhar Fahriansyah", "1302220056"),
};

            // Tambahkan daftar Mahasiswa ke dalam layanan
            builder.Services.AddSingleton(mahasiswaList);

            var app = builder.Build();
            // Route untuk menampilkan semua Mahasiswa
            app.MapGet("/api/mahasiswa", () => mahasiswaList.ToArray());

            // Route untuk menampilkan Mahasiswa berdasarkan NIM
            app.MapGet("/api/mahasiswa/{nim}", (string nim) =>
            {
                var mahasiswa = mahasiswaList.Find(m => m.getNim() == nim);
                if (mahasiswa != null)
                {
                    return Results.Ok(mahasiswa);
                }
                return Results.NotFound();
            });

            // Route untuk menambahkan Mahasiswa baru
            app.MapPost("/api/mahasiswa", (Mahasiswa mahasiswa) =>
            {
                // Validasi data mahasiswa
                if (string.IsNullOrEmpty(mahasiswa.getNim()) || string.IsNullOrEmpty(mahasiswa.getNim()))
                {
                    return Results.BadRequest("Nama dan NIM tidak boleh kosong");
                }
                if (mahasiswaList.Any(m => m.getNim() == mahasiswa.getNim()))
                {
                    return Results.BadRequest("NIM sudah ada");
                }
                mahasiswaList.Add(mahasiswa);
                return Results.Created($"/api/mahasiswa/{mahasiswa.getNim()}", mahasiswa);
            });

            // Route untuk menghapus Mahasiswa berdasarkan NIM
            app.MapDelete("/api/mahasiswa/{nim}", (string nim) =>
            {
                var mahasiswa = mahasiswaList.Find(m => m.getNim() == nim);
                if (mahasiswa != null)
                {
                    mahasiswaList.Remove(mahasiswa);
                    return Results.NoContent();
                }
                return Results.NotFound();
            });

            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
