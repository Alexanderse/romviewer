
using System;
using System.Collections.Generic;
using NHibernate.Mapping.ByCode;
using NHibernate.Type;
using NHibernate.UserTypes;
using RomViewer.Core.Character;
using RomViewer.Core.Mapping;
using RomViewer.Core.NPCs;
using RomViewer.Core.Quests;

namespace RomViewer.NHibernateProvider.Overrides
{
    public class RomViewerOverrides : IOverride
    {
        public void Override(ModelMapper mapper)
        {
            mapper.Class<MapLink>(map => 
                                      {
                                          map.ManyToOne<MapPoint>(link => link.Start, many21 =>
                                                                                          {
                                                                                              many21.Column("MapPointFk");
                                                                                              many21.Lazy(LazyRelation.Proxy);
                                                                                              many21.NotNullable(true);
                                                                                              many21.Cascade(Cascade.All);
                                                                                          });


                                          map.ManyToOne<MapPoint>(link => link.End, one21 =>
                                                                                        {
                                                                                            one21.Column("MapPointEndFk");
                                                                                            one21.Lazy(LazyRelation.NoLazy);
                                                                                            one21.NotNullable(true);
                                                                                            one21.Cascade(Cascade.All);
                                                                                        });
                                      });

            //mapper.Class<MapPoint>(map => map.Property(p=>p.TeleportLinks,links=>links.Formula("")));
            mapper.Class<CharacterDefinition>(map => map.Bag(x => x.CompletedQuests, set =>
                                                        {
                                                            set.Key(key =>
                                                                {
                                                                    key.Column(
                                                                        "CharacterId");
                                                                    key.ForeignKey(
                                                                        "FK_Character_QuestDefinitionId");
                                                                });
                                                            set.Table("Character_QuestDefinition");
                                                        },
                                                        ce=>ce.ManyToMany(m=>m.Column("QuestDefinitionId"))));


        }
    }


}