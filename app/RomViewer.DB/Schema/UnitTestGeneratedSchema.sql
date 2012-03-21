
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7026D903B92E0EAB]') AND parent_object_id = OBJECT_ID('MapLinks'))
alter table MapLinks  drop constraint FK7026D903B92E0EAB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7026D9039FDC0ABA]') AND parent_object_id = OBJECT_ID('MapLinks'))
alter table MapLinks  drop constraint FK7026D9039FDC0ABA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCA74643ABCA0AE01]') AND parent_object_id = OBJECT_ID('TeleportLinks'))
alter table TeleportLinks  drop constraint FKCA74643ABCA0AE01


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCA74643AB92E0EAB]') AND parent_object_id = OBJECT_ID('TeleportLinks'))
alter table TeleportLinks  drop constraint FKCA74643AB92E0EAB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF3B88A97DA4817DB]') AND parent_object_id = OBJECT_ID('MapPoints'))
alter table MapPoints  drop constraint FKF3B88A97DA4817DB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK468D8D68C7EA1E75]') AND parent_object_id = OBJECT_ID('QuestRewards'))
alter table QuestRewards  drop constraint FK468D8D68C7EA1E75


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK468D8D685CF78982]') AND parent_object_id = OBJECT_ID('QuestRewards'))
alter table QuestRewards  drop constraint FK468D8D685CF78982


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE04BAEAB6D885A]') AND parent_object_id = OBJECT_ID('QuestDefinitions'))
alter table QuestDefinitions  drop constraint FKE04BAEAB6D885A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7A67F8B551B98ED0]') AND parent_object_id = OBJECT_ID('Character_QuestDefinition'))
alter table Character_QuestDefinition  drop constraint FK7A67F8B551B98ED0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_Character_QuestDefinitionId]') AND parent_object_id = OBJECT_ID('Character_QuestDefinition'))
alter table Character_QuestDefinition  drop constraint FK_Character_QuestDefinitionId


    if exists (select * from dbo.sysobjects where id = object_id(N'ItemDefinitions') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table ItemDefinitions

    if exists (select * from dbo.sysobjects where id = object_id(N'MapLinks') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table MapLinks

    if exists (select * from dbo.sysobjects where id = object_id(N'TeleportLinks') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table TeleportLinks

    if exists (select * from dbo.sysobjects where id = object_id(N'MapPoints') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table MapPoints

    if exists (select * from dbo.sysobjects where id = object_id(N'QuestRewards') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table QuestRewards

    if exists (select * from dbo.sysobjects where id = object_id(N'QuestChains') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table QuestChains

    if exists (select * from dbo.sysobjects where id = object_id(N'NonPlayerEntities') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table NonPlayerEntities

    if exists (select * from dbo.sysobjects where id = object_id(N'QuestDefinitions') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table QuestDefinitions

    if exists (select * from dbo.sysobjects where id = object_id(N'MapZones') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table MapZones

    if exists (select * from dbo.sysobjects where id = object_id(N'CharacterDefinitions') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table CharacterDefinitions

    if exists (select * from dbo.sysobjects where id = object_id(N'Character_QuestDefinition') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Character_QuestDefinition

    create table ItemDefinitions (
        Id INT IDENTITY NOT NULL,
       RomId INT null,
       Name NVARCHAR(255) null,
       Value INT null,
       ItemType NVARCHAR(255) null,
       ItemSubType NVARCHAR(255) null,
       ItemSubSubType NVARCHAR(255) null,
       RequiredLevel INT null,
       primary key (Id)
    )

    create table MapLinks (
        Id INT IDENTITY NOT NULL,
       MapPointFk INT not null,
       MapPointEndFk INT not null,
       LinkType INT null,
       Script NVARCHAR(255) null,
       primary key (Id)
    )

    create table TeleportLinks (
        Id INT IDENTITY NOT NULL,
       NonPlayerEntityFk INT null,
       MapPointFk INT null,
       LinkType INT null,
       Script NVARCHAR(255) null,
       primary key (Id)
    )

    create table MapPoints (
        Id INT IDENTITY NOT NULL,
       X DOUBLE PRECISION null,
       Y DOUBLE PRECISION null,
       Z DOUBLE PRECISION null,
       MapZoneFk INT null,
       Name NVARCHAR(255) null,
       primary key (Id)
    )

    create table QuestRewards (
        Id INT IDENTITY NOT NULL,
       RewardIndex INT null,
       RewardType NVARCHAR(255) null,
       ItemDefinitionFk INT null,
       QuestDefinitionFk INT null,
       ItemCount INT null,
       primary key (Id)
    )

    create table QuestChains (
        Id INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       primary key (Id)
    )

    create table NonPlayerEntities (
        Id INT IDENTITY NOT NULL,
       RomId INT null,
       UniqueId INT null,
       Name NVARCHAR(255) null,
       ZoneId INT null,
       X DOUBLE PRECISION null,
       Y DOUBLE PRECISION null,
       Z DOUBLE PRECISION null,
       EntityTypes TINYINT null,
       primary key (Id)
    )

    create table QuestDefinitions (
        Id INT IDENTITY NOT NULL,
       RomId INT null,
       Name NVARCHAR(255) null,
       MinLevel INT null,
       Level INT null,
       StarterId INT null,
       EnderId INT null,
       Gold INT null,
       XP INT null,
       TP INT null,
       RewardCategory INT null,
       RewardSubCategory INT null,
       QuestChainFk INT null,
       ChainIndex INT null,
       primary key (Id)
    )

    create table MapZones (
        Id INT IDENTITY NOT NULL,
       RomId INT null,
       Name NVARCHAR(255) null,
       IsPublic BIT null,
       primary key (Id)
    )

    create table CharacterDefinitions (
        Id INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Race NVARCHAR(255) null,
       Sex INT null,
       PrimaryClass INT null,
       PrimaryLevel INT null,
       SecondayClass INT null,
       SecondaryLevel INT null,
       ThirdClass INT null,
       ThirdLevel INT null,
       primary key (Id)
    )

    create table Character_QuestDefinition (
        CharacterId INT not null,
       QuestDefinitionId INT not null
    )

    alter table MapLinks 
        add constraint FK7026D903B92E0EAB 
        foreign key (MapPointFk) 
        references MapPoints

    alter table MapLinks 
        add constraint FK7026D9039FDC0ABA 
        foreign key (MapPointEndFk) 
        references MapPoints

    alter table TeleportLinks 
        add constraint FKCA74643ABCA0AE01 
        foreign key (NonPlayerEntityFk) 
        references NonPlayerEntities

    alter table TeleportLinks 
        add constraint FKCA74643AB92E0EAB 
        foreign key (MapPointFk) 
        references MapPoints

    alter table MapPoints 
        add constraint FKF3B88A97DA4817DB 
        foreign key (MapZoneFk) 
        references MapZones

    alter table QuestRewards 
        add constraint FK468D8D68C7EA1E75 
        foreign key (ItemDefinitionFk) 
        references ItemDefinitions

    alter table QuestRewards 
        add constraint FK468D8D685CF78982 
        foreign key (QuestDefinitionFk) 
        references QuestDefinitions

    alter table QuestDefinitions 
        add constraint FKE04BAEAB6D885A 
        foreign key (QuestChainFk) 
        references QuestChains

    alter table Character_QuestDefinition 
        add constraint FK7A67F8B551B98ED0 
        foreign key (QuestDefinitionId) 
        references QuestDefinitions

    alter table Character_QuestDefinition 
        add constraint FK_Character_QuestDefinitionId 
        foreign key (CharacterId) 
        references CharacterDefinitions
