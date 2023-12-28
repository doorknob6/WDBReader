using Microsoft.Extensions.DependencyInjection;
using WdbReader.Model;
using WdbReader.Options;

namespace TestWdbReader.Helpers
{
    public static class OptionsHelper
    {
        #region Fields

        private static readonly WdbOptions _gameObjectCacheOptions =
            new()
            {
                FileName = "gameobjectcache.wdb",
                HeaderOptions = new()
                {
                    Signature = "WGOB",
                    Version = 5875u,
                    RecordLengthRecordName = null,
                    RecordOptions = new()
                    {
                        new()
                        {
                            DataType = WdbRecordDataType.StringType,
                            IsReversed = true,
                            Length = 4,
                            Name = "Signature"
                        },
                        new()
                        {
                            DataType = WdbRecordDataType.IntegerType,
                            IsReversed = false,
                            Length = 4,
                            Name = "Version"
                        },
                        new()
                        {
                            DataType = WdbRecordDataType.StringType,
                            IsReversed = true,
                            Length = 4,
                            Name = "Locale"
                        },
                        new()
                        {
                            DataType = WdbRecordDataType.IntegerType,
                            IsReversed = false,
                            Length = 4,
                            Name = "RecordSize"
                        },
                        new()
                        {
                            DataType = WdbRecordDataType.IntegerType,
                            IsReversed = false,
                            Length = 4,
                            Name = "RecordVersion"
                        }
                    }
                },
                RecordLengthRecordName = "RecordLength",
                RecordOptions = new()
                {
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Identifier"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "RecordLength"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "ObjectType"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "DisplayId"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.StringNullType,
                        IsReversed = false,
                        Length = 4,
                        Name = "NameOne"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.StringNullType,
                        IsReversed = false,
                        Length = 4,
                        Name = "NameTwo"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.StringNullType,
                        IsReversed = false,
                        Length = 4,
                        Name = "NameThree"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.StringNullType,
                        IsReversed = false,
                        Length = 4,
                        Name = "NameFour"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.StringNullType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Unknown1"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Data00"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Data01"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Data02"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Data03"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Data04"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Data05"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Data06"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Data07"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Data08"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Data09"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Data10"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Data11"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Data12"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Data13"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Data14"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Data15"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Data16"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Data17"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Data18"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Data19"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Data20"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Data21"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Data22"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Data23"
                    }
                }
            };

        private static readonly WdbOptions _itemCacheOptions =
            new()
            {
                FileName = "itemcache.wdb",
                HeaderOptions = new()
                {
                    Signature = "WIDB",
                    Version = 5875u,
                    RecordOptions = new()
                    {
                        new()
                        {
                            DataType = WdbRecordDataType.StringType,
                            IsReversed = true,
                            Length = 4,
                            Name = "Signature"
                        },
                        new()
                        {
                            Length = 4,
                            Name = "Version",
                            DataType = WdbRecordDataType.IntegerType,
                            IsReversed = false
                        },
                        new()
                        {
                            DataType = WdbRecordDataType.StringType,
                            IsReversed = true,
                            Length = 4,
                            Name = "Locale"
                        },
                        new()
                        {
                            Length = 4,
                            Name = "RecordSize",
                            DataType = WdbRecordDataType.IntegerType,
                            IsReversed = false
                        },
                        new()
                        {
                            Length = 4,
                            Name = "RecordVersion",
                            DataType = WdbRecordDataType.IntegerType,
                            IsReversed = false
                        }
                    }
                },
                RecordLengthRecordName = "RecordLength",
                RecordOptions = new()
                {
                    new()
                    {
                        Length = 4,
                        Name = "Identifier",
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false
                    },
                    new()
                    {
                        Length = 4,
                        Name = "RecordLength",
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false
                    },
                    new()
                    {
                        Length = 4,
                        Name = "ItemClass",
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false
                    },
                    new()
                    {
                        Length = 4,
                        Name = "ItemSubClass",
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.StringNullType,
                        Length = 4,
                        IsReversed = false,
                        Name = "NameOne"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.StringNullType,
                        Length = 4,
                        IsReversed = false,
                        Name = "NameTwo"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.StringNullType,
                        Length = 4,
                        IsReversed = false,
                        Name = "NameThree"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.StringNullType,
                        Length = 4,
                        IsReversed = false,
                        Name = "NameFour"
                    },
                    new()
                    {
                        Length = 4,
                        Name = "DisplayId",
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false
                    },
                    new()
                    {
                        Length = 4,
                        Name = "Quality",
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.BitMaskType,
                        Length = 4,
                        IsReversed = false,
                        Name = "Flags"
                    },
                    new()
                    {
                        Length = 4,
                        Name = "BuyPrice",
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false
                    },
                    new()
                    {
                        Length = 4,
                        Name = "SellPrice",
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false
                    },
                    new()
                    {
                        Length = 4,
                        Name = "InventorySlot",
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.BitMaskType,
                        Length = 4,
                        IsReversed = false,
                        Name = "AllowableClass"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.BitMaskType,
                        Length = 4,
                        IsReversed = false,
                        Name = "AllowableRace"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "ItemLevel"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "RequiredLevel"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "RequiredSkill"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "RequiredSkillRank"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "RequiredSpell"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "RequiredHonorRank"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "RequiredCityRank"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "RequiredReputationFaction"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "RequiredReputationRank"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "MaxCount"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Stackable"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "ContainerSlots"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Stat1Id"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Stat1Value"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Stat2Id"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Stat2Value"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Stat3Id"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Stat3Value"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Stat4Id"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Stat4Value"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Stat5Id"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Stat5Value"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Stat6Id"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Stat6Value"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Stat7Id"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Stat7Value"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Stat8Id"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Stat8Value"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Stat9Id"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Stat9Value"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Stat10Id"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Stat10Value"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.FloatType,
                        Length = 4,
                        IsReversed = false,
                        Name = "Damage1Min"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.FloatType,
                        Length = 4,
                        IsReversed = false,
                        Name = "Damage1Max"
                    },
                    new()
                    {
                        Length = 4,
                        Name = "Damage1Type",
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.FloatType,
                        Length = 4,
                        IsReversed = false,
                        Name = "Damage2Min"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.FloatType,
                        Length = 4,
                        IsReversed = false,
                        Name = "Damage2Max"
                    },
                    new()
                    {
                        Length = 4,
                        Name = "Damage2Type",
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.FloatType,
                        Length = 4,
                        IsReversed = false,
                        Name = "Damage3Min"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.FloatType,
                        Length = 4,
                        IsReversed = false,
                        Name = "Damage3Max"
                    },
                    new()
                    {
                        Length = 4,
                        Name = "Damage3Type",
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.FloatType,
                        Length = 4,
                        IsReversed = false,
                        Name = "Damage4Min"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.FloatType,
                        Length = 4,
                        IsReversed = false,
                        Name = "Damage4Max"
                    },
                    new()
                    {
                        Length = 4,
                        Name = "Damage4Type",
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.FloatType,
                        Length = 4,
                        IsReversed = false,
                        Name = "Damage5Min"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.FloatType,
                        Length = 4,
                        IsReversed = false,
                        Name = "Damage5Max"
                    },
                    new()
                    {
                        Length = 4,
                        Name = "Damage5Type",
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false
                    },
                    new()
                    {
                        Length = 4,
                        Name = "ResistPhysical",
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false
                    },
                    new()
                    {
                        Length = 4,
                        Name = "ResistHoly",
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false
                    },
                    new()
                    {
                        Length = 4,
                        Name = "ResistFire",
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false
                    },
                    new()
                    {
                        Length = 4,
                        Name = "ResistNature",
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false
                    },
                    new()
                    {
                        Length = 4,
                        Name = "ResistFrost",
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false
                    },
                    new()
                    {
                        Length = 4,
                        Name = "ResistShadow",
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false
                    },
                    new()
                    {
                        Length = 4,
                        Name = "ResistArcane",
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false
                    },
                    new()
                    {
                        Length = 4,
                        Name = "WeaponDelay",
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false
                    },
                    new()
                    {
                        Length = 4,
                        Name = "AmmoType",
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.FloatType,
                        Length = 4,
                        IsReversed = false,
                        Name = "RangeModifier"
                    },
                    new()
                    {
                        Length = 4,
                        Name = "Spell1Id",
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Spell1TriggerId"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Spell1Charges"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Spell1Cooldown"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Spell1CategoryId"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Spell1CategoryCooldown"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Spell2Id"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Spell2TriggerId"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Spell2Charges"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Spell2Cooldown"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Spell2CategoryId"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Spell2CategoryCooldown"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Spell3Id"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Spell3TriggerId"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Spell3Charges"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Spell3Cooldown"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Spell3CategoryId"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Spell3CategoryCooldown"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Spell4Id"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Spell4TriggerId"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Spell4Charges"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Spell4Cooldown"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Spell4CategoryId"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Spell4CategoryCooldown"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Spell5Id"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Spell5TriggerId"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Spell5Charges"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Spell5Cooldown"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Spell5CategoryId"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "Spell5CategoryCooldown"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "BondId"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.StringNullType,
                        Length = 4,
                        IsReversed = false,
                        Name = "Description"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "BookTextId"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "BookPages"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "BookStationaryId"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "BeginQuestId"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "LockPickTalent"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "MaterialId"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "SheathId"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "RandompropertyId"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "BlockValue"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "ItemSetId"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "DurabilityValue"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "ItemAreaId"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "ItemMapId"
                    },
                    new()
                    {
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4,
                        Name = "BagFamily"
                    }
                }
            };

        private static readonly WdbReaderOptions _wdbReaderOptions =
            new()
            {
                WdbOptions = new() { _itemCacheOptions, _gameObjectCacheOptions }
            };

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the game object cache options.
        /// </summary>
        /// <remarks>
        /// These are the options for the gameobjectcache.wdb file as it is present in the directory 'resources/wdb'.
        /// </remarks>
        public static WdbOptions GameObjectCacheOptions => _gameObjectCacheOptions;

        /// <summary>
        /// Gets the item cache options.
        /// </summary>
        /// <remarks>
        /// These are the options for the itemcache.wdb file as it is present in the directory 'resources/wdb'.
        /// </remarks>
        public static WdbOptions ItemCacheOptions => _itemCacheOptions;

        /// <summary>
        /// Gets the wdb reader options.
        /// </summary>
        /// <remarks>
        /// These are the options for the .wdb files as they are present in the directory 'resources/wdb'.
        /// </remarks>
        public static WdbReaderOptions WdbReaderOptions => _wdbReaderOptions;

        #endregion Properties

        #region Methods

        /// <summary>
        /// This extension method adds the <see cref="WdbReaderOptions"/> defined in this helper
        /// class to the service collection.
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <returns></returns>
        public static IServiceCollection AddTestWdbReaderOptions(
            this IServiceCollection serviceCollection
        )
        {
            serviceCollection
                .AddOptions<WdbReaderOptions>()
                .PostConfigure(options =>
                {
                    options.WdbOptions = WdbReaderOptions.WdbOptions;
                });
            return serviceCollection;
        }

        #endregion Methods
    }
}
