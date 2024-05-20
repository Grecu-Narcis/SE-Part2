﻿// <auto-generated />
using System;
using Iss.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Iss.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240518173054_ChangedDB2")]
    partial class ChangedDB2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Iss.Entity.Ad", b =>
                {
                    b.Property<string>("AdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AdAccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AdSetId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebsiteLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdId");

                    b.HasIndex("AdAccountId");

                    b.HasIndex("AdSetId");

                    b.ToTable("Ad");
                });

            modelBuilder.Entity("Iss.Entity.AdAccount", b =>
                {
                    b.Property<string>("AdAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AuthorisingInstituion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DomainOfActivity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HeadquartersLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameOfCompany")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxIdentificationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdAccountId");

                    b.ToTable("AdAccount");
                });

            modelBuilder.Entity("Iss.Entity.AdSet", b =>
                {
                    b.Property<string>("AdSetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AdAccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CampaignId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TargetAudience")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdSetId");

                    b.HasIndex("AdAccountId");

                    b.HasIndex("CampaignId");

                    b.ToTable("AdSet");
                });

            modelBuilder.Entity("Iss.Entity.Campaign", b =>
                {
                    b.Property<string>("CampaignId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AdAccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CampaignName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CampaignId");

                    b.HasIndex("AdAccountId");

                    b.ToTable("Campaign");
                });

            modelBuilder.Entity("Iss.Entity.Collaboration", b =>
                {
                    b.Property<int>("CollaborationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CollaborationId"));

                    b.Property<string>("AdAccountId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AdOverview")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CollaborationFee")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CollaborationTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentRequirement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InfluencerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("CollaborationId");

                    b.HasIndex("AdAccountId");

                    b.HasIndex("InfluencerId");

                    b.ToTable("Collaboration");
                });

            modelBuilder.Entity("Iss.Entity.Influencer", b =>
                {
                    b.Property<string>("InfluencerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CollaborationPrice")
                        .HasColumnType("int");

                    b.Property<int>("FollowerCount")
                        .HasColumnType("int");

                    b.Property<string>("InfluencerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InfluencerId");

                    b.ToTable("Influencer");
                });

            modelBuilder.Entity("Iss.Entity.Request", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestId"));

                    b.Property<bool>("AdAccountAccept")
                        .HasColumnType("bit");

                    b.Property<string>("AdOverview")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CollaborationTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Compensation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentRequirements")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("InfluencerAccept")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RequestId");

                    b.ToTable("Request");
                });

            modelBuilder.Entity("Iss.Entity.Ad", b =>
                {
                    b.HasOne("Iss.Entity.AdAccount", null)
                        .WithMany("Ads")
                        .HasForeignKey("AdAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Iss.Entity.AdSet", null)
                        .WithMany("Ads")
                        .HasForeignKey("AdSetId");
                });

            modelBuilder.Entity("Iss.Entity.AdSet", b =>
                {
                    b.HasOne("Iss.Entity.AdAccount", null)
                        .WithMany("AdSets")
                        .HasForeignKey("AdAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Iss.Entity.Campaign", null)
                        .WithMany("AdSets")
                        .HasForeignKey("CampaignId");
                });

            modelBuilder.Entity("Iss.Entity.Campaign", b =>
                {
                    b.HasOne("Iss.Entity.AdAccount", "AdAccount")
                        .WithMany("Campaigns")
                        .HasForeignKey("AdAccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AdAccount");
                });

            modelBuilder.Entity("Iss.Entity.Collaboration", b =>
                {
                    b.HasOne("Iss.Entity.AdAccount", null)
                        .WithMany("Collaborations")
                        .HasForeignKey("AdAccountId");

                    b.HasOne("Iss.Entity.Influencer", null)
                        .WithMany("Collaborations")
                        .HasForeignKey("InfluencerId");
                });

            modelBuilder.Entity("Iss.Entity.AdAccount", b =>
                {
                    b.Navigation("AdSets");

                    b.Navigation("Ads");

                    b.Navigation("Campaigns");

                    b.Navigation("Collaborations");
                });

            modelBuilder.Entity("Iss.Entity.AdSet", b =>
                {
                    b.Navigation("Ads");
                });

            modelBuilder.Entity("Iss.Entity.Campaign", b =>
                {
                    b.Navigation("AdSets");
                });

            modelBuilder.Entity("Iss.Entity.Influencer", b =>
                {
                    b.Navigation("Collaborations");
                });
#pragma warning restore 612, 618
        }
    }
}
