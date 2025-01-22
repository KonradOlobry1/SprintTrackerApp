﻿// <auto-generated />
using System;
using DummyProject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DummyProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250118183310_ModifyTaskItem")]
    partial class ModifyTaskItem
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("DummyProject.Models.SprintItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Sprints");
                });

            modelBuilder.Entity("DummyProject.Models.TaskItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StoryPoints")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("DummyProject.Models.TaskProgress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CompletedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Day")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StoryPointsCompleted")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TaskItemId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TaskItemId");

                    b.ToTable("TaskProgress");
                });

            modelBuilder.Entity("SprintItemTaskItem", b =>
                {
                    b.Property<int>("SprintItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TasksId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SprintItemId", "TasksId");

                    b.HasIndex("TasksId");

                    b.ToTable("SprintItemTaskItem");
                });

            modelBuilder.Entity("DummyProject.Models.TaskProgress", b =>
                {
                    b.HasOne("DummyProject.Models.TaskItem", null)
                        .WithMany("Progress")
                        .HasForeignKey("TaskItemId");
                });

            modelBuilder.Entity("SprintItemTaskItem", b =>
                {
                    b.HasOne("DummyProject.Models.SprintItem", null)
                        .WithMany()
                        .HasForeignKey("SprintItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DummyProject.Models.TaskItem", null)
                        .WithMany()
                        .HasForeignKey("TasksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DummyProject.Models.TaskItem", b =>
                {
                    b.Navigation("Progress");
                });
#pragma warning restore 612, 618
        }
    }
}
