﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task_Manager_API.Data;

#nullable disable

namespace Task_Manager_API.Migrations
{
    [DbContext(typeof(TaskManagerDBContext))]
    partial class TaskManagerDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Task_Manager_API.Models.Domain.TaskManager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("TargetTimeinHours")
                        .HasColumnType("float");

                    b.Property<string>("TaskDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TargetTimeinHours = 3.0,
                            TaskDescription = "Studying for new Job",
                            TaskName = "Study"
                        },
                        new
                        {
                            Id = 2,
                            TargetTimeinHours = 0.5,
                            TaskDescription = "",
                            TaskName = "Running"
                        },
                        new
                        {
                            Id = 3,
                            TargetTimeinHours = 1.0,
                            TaskDescription = "",
                            TaskName = "Workout"
                        },
                        new
                        {
                            Id = 4,
                            TargetTimeinHours = 2.0,
                            TaskDescription = "Learning Cooking for Birthday",
                            TaskName = "Cooking"
                        },
                        new
                        {
                            Id = 5,
                            TargetTimeinHours = 0.5,
                            TaskDescription = "",
                            TaskName = "Yoga"
                        },
                        new
                        {
                            Id = 6,
                            TargetTimeinHours = 2.0,
                            TaskDescription = "",
                            TaskName = "project Completion"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
