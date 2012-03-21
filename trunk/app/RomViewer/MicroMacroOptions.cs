using System.ComponentModel;

namespace RomViewer
{
    public delegate void OnChangeOptionValueDelegate(string option, string value);

    public class MicroMacroOptions
    {
        private string _DEBUG;
        private string _DEBUG_TARGET;
        private string _DEBUG_LOOT;
        private string _DEBUG_MACRO;
        private string _DEBUG_HARVEST;
        private string _DEBUG_WAYPOINT;
        private string _DEBUG_AUTOSELL;

        private string _HP_LOW;
        private string _MP_LOW_POTION;
        private string _HP_LOW_POTION;
        private string _USE_HP_POTION;
        private string _USE_MANA_POTION;
        private string _HP_REST;
        private string _MP_REST;
        private string _HEALING_POTION;
        private string _MANA_POTION;

        private string _ARROW_QUIVER;
        private string _THROWN_BAG;
        private string _POISON;
        private string _RELOAD_AMMUNITION;

        private string _COMBAT_TYPE;
        private string _COMBAT_RANGED_PULL;
        private string _COMBAT_DISTANCE;
        private string _MAX_FIGHT_TIME;
        private string _DOT_PERCENT;
        private string _ANTI_KS;
        private string _MAX_TARGET_DIST;

        private bool _INV_AUTOSELL_ENABLE;
        private string _INV_AUTOSELL_FROMSLOT;
        private string _INV_AUTOSELL_TOSLOT;
        private string _INV_AUTOSELL_QUALITY;
        private string _INV_AUTOSELL_IGNORE;
        private string _INV_AUTOSELL_TYPES;
        private string _INV_AUTOSELL_TYPES_NOSELL;
        private string _TARGET_LEVELDIF_ABOVE;
        private string _TARGET_LEVELDIF_BELOW;
        private string _WAYPOINTS;
        private string _RETURNPATH;
        private string _PATH_TYPE;
        private string _WANDER_RADIUS;
        private string _WAYPOINT_DEVIATION;
        private string _QUICK_TURN;
        private bool _LOOT;
        private bool _LOOT_ALL;
        private string _LOOT_IN_COMBAT;
        private string _LOOT_DISTANCE;
        private string _LOOT_PAUSE_AFTER;
        private string _HARVEST_DISTANCE;
        private string _HARVEST_WOOD;
        private string _HARVEST_HERB;
        private string _HARVEST_ORE;
        private string _EGGPET_ENABLE_CRAFT;
        private string _EGGPET_CRAFT_SLOT;
        private string _EGGPET_ENABLE_ASSIST;
        private string _EGGPET_ASSIST_SLOT;
        private string _EGGPET_CRAFT_RATIO;
        private string _EGGPET_CRAFT_INDEXES;
        private string _LOGOUT_TIME;
        private string _LOGOUT_SHUTDOWN;
        private string _LOGOUT_WHEN_STUCK;
        private string _CLOSE_WHEN_STUCK;
        private string _RES_AUTOMATIC_AFTER_DEATH;
        private string _MAX_DEATHS;
        private string _MAX_UNSTICK_TRIALS;
        private string _PARTY;
        private string _PARTY_ICONS;
        private string _PARTY_INSTANCE;
        private string _UDP_ENABLED;
        private string _UDP_HOST;
        private string _UDP_HOSTPORT;
        private string _UDP_LOCALPORT;
        private string _STOP_TARGET_CLEARING;

        [Category("Health and Mana")]
        public string HP_LOW
        {
            get { return _HP_LOW; }
            set
            {
                _HP_LOW = value;
                DoOnChange("HP_LOW", value);
            }
        }

        [Category("Health and Mana")]
        public string MP_LOW_POTION
        {
            get { return _MP_LOW_POTION; }
            set
            {
                _MP_LOW_POTION = value;
                DoOnChange("MP_LOW_POTION", value);
            }
        }

        [Category("Health and Mana")]
        public string HP_LOW_POTION
        {
            get { return _HP_LOW_POTION; }
            set
            {
                _HP_LOW_POTION = value;
                DoOnChange("HP_LOW_POTION", value);
            }
        }

        [Category("Health and Mana")]
        public string USE_HP_POTION
        {
            get { return _USE_HP_POTION; }
            set
            {
                _USE_HP_POTION = value;
                DoOnChange("USE_HP_POTION", value);
            }
        }

        [Category("Health and Mana")]
        public string USE_MANA_POTION
        {
            get { return _USE_MANA_POTION; }
            set
            {
                _USE_MANA_POTION = value;
                DoOnChange("USE_MANA_POTION", value);
            }
        }

        //-- Rest if HP or Mana is below that level -->
        [Category("Health and Mana")]
        public string HP_REST
        {
            get { return _HP_REST; }
            set
            {
                _HP_REST = value;
                DoOnChange("HP_REST", value);
            }
        }

        [Category("Health and Mana")]
        public string MP_REST
        {
            get { return _MP_REST; }
            set
            {
                _MP_REST = value;
                DoOnChange("MP_REST", value);
            }
        }

        //-- Shopping options, how many of what do you want to keep in your inventory -->
        [Category("Shopping")]
        public string HEALING_POTION
        {
            get { return _HEALING_POTION; }
            set
            {
                _HEALING_POTION = value;
                DoOnChange("HEALING_POTION", value);
            }
        }

        [Category("Shopping")]
        public string MANA_POTION
        {
            get { return _MANA_POTION; }
            set
            {
                _MANA_POTION = value;
                DoOnChange("MANA_POTION", value);
            }
        }

        [Category("Shopping")]
        public string ARROW_QUIVER
        {
            get { return _ARROW_QUIVER; }
            set
            {
                _ARROW_QUIVER = value;
                DoOnChange("ARROW_QUIVER", value);
            }
        }

        [Category("Shopping")]
        public string THROWN_BAG
        {
            get { return _THROWN_BAG; }
            set
            {
                _THROWN_BAG = value;
                DoOnChange("THROWN_BAG", value);
            }
        }

        [Category("Shopping")]
        public string POISON
        {
            get { return _POISON; }
            set
            {
                _POISON = value;
                DoOnChange("POISON", value);
            }
        }

        //-- either false or arrow or thrown -->
        [Category("Ammo")]
        public string RELOAD_AMMUNITION
        {
            get { return _RELOAD_AMMUNITION; }
            set
            {
                _RELOAD_AMMUNITION = value;
                DoOnChange("RELOAD_AMMUNITION", value);
            }
        }

        //-- Combat options -->
        [Category("Combat")]
        public string COMBAT_TYPE
        {
            get { return _COMBAT_TYPE; }
            set
            {
                _COMBAT_TYPE = value;
                DoOnChange("COMBAT_TYPE", value);
            }
        }

        [Category("Combat")]
        public string COMBAT_RANGED_PULL
        {
            get { return _COMBAT_RANGED_PULL; }
            set
            {
                _COMBAT_RANGED_PULL = value;
                DoOnChange("COMBAT_RANGED_PULL", value);
            }
        }

        [Category("Combat")]
        public string COMBAT_DISTANCE
        {
            get { return _COMBAT_DISTANCE; }
            set
            {
                _COMBAT_DISTANCE = value;
                DoOnChange("COMBAT_DISTANCE", value);
            }
        }

        [Category("Combat")]
        public string MAX_FIGHT_TIME
        {
            get { return _MAX_FIGHT_TIME; }
            set
            {
                _MAX_FIGHT_TIME = value;
                DoOnChange("MAX_FIGHT_TIME", value);
            }
        }

        [Category("Combat")]
        public string DOT_PERCENT
        {
            get { return _DOT_PERCENT; }
            set
            {
                _DOT_PERCENT = value;
                DoOnChange("DOT_PERCENT", value);
            }
        }

        [Category("Combat")]
        public string ANTI_KS
        {
            get { return _ANTI_KS; }
            set
            {
                _ANTI_KS = value;
                DoOnChange("ANTI_KS", value);
            }
        }

        [Category("Combat")]
        public string MAX_TARGET_DIST
        {
            get { return _MAX_TARGET_DIST; }
            set
            {
                _MAX_TARGET_DIST = value;
                DoOnChange("MAX_TARGET_DIST", value);
            }
        }

        [Category("Shopping")]
        public bool INV_AUTOSELL_ENABLE
        {
            get { return _INV_AUTOSELL_ENABLE; }
            set
            {
                _INV_AUTOSELL_ENABLE = value;
                DoOnChange("INV_AUTOSELL_ENABLE", value.ToString());
            }
        }

        [Category("Shopping")]
        public string INV_AUTOSELL_FROMSLOT
        {
            get { return _INV_AUTOSELL_FROMSLOT; }
            set
            {
                _INV_AUTOSELL_FROMSLOT = value;
                DoOnChange("INV_AUTOSELL_FROMSLOT", value);
            }
        }

        [Category("Shopping")]
        public string INV_AUTOSELL_TOSLOT
        {
            get { return _INV_AUTOSELL_TOSLOT; }
            set
            {
                _INV_AUTOSELL_TOSLOT = value;
                DoOnChange("INV_AUTOSELL_TOSLOT", value);
            }
        }

        [Category("Shopping")]
        public string INV_AUTOSELL_QUALITY
        {
            get { return _INV_AUTOSELL_QUALITY; }
            set
            {
                _INV_AUTOSELL_QUALITY = value;
                DoOnChange("INV_AUTOSELL_QUALITY", value);
            }
        }

        [Category("Shopping")]
        public string INV_AUTOSELL_IGNORE
        {
            get { return _INV_AUTOSELL_IGNORE; }
            set
            {
                _INV_AUTOSELL_IGNORE = value;
                DoOnChange("INV_AUTOSELL_IGNORE", value);
            }
        }

        [Category("Shopping")]
        public string INV_AUTOSELL_TYPES
        {
            get { return _INV_AUTOSELL_TYPES; }
            set
            {
                _INV_AUTOSELL_TYPES = value;
                DoOnChange("INV_AUTOSELL_TYPES", value);
            }
        }

        [Category("Shopping")]
        public string INV_AUTOSELL_TYPES_NOSELL
        {
            get { return _INV_AUTOSELL_TYPES_NOSELL; }
            set
            {
                _INV_AUTOSELL_TYPES_NOSELL = value;
                DoOnChange("INV_AUTOSELL_TYPES_NOSELL", value);
            }
        }

        //-- Attack monsters 3 levels above or 10 below your level -->
        [Category("Targetting")]
        public string TARGET_LEVELDIF_ABOVE
        {
            get { return _TARGET_LEVELDIF_ABOVE; }
            set
            {
                _TARGET_LEVELDIF_ABOVE = value;
                DoOnChange("TARGET_LEVELDIF_ABOVE", value);
            }
        }

        [Category("Targetting")]
        public string TARGET_LEVELDIF_BELOW
        {
            get { return _TARGET_LEVELDIF_BELOW; }
            set
            {
                _TARGET_LEVELDIF_BELOW = value;
                DoOnChange("TARGET_LEVELDIF_BELOW", value);
            }
        }

        //-- Waypoint and movement settings -->
        [Category("Movement")]
        public string WAYPOINTS
        {
            get { return _WAYPOINTS; }
            set
            {
                _WAYPOINTS = value;
                DoOnChange("WAYPOINTS", value);
            }
        }

        [Category("Movement")]
        public string RETURNPATH
        {
            get { return _RETURNPATH; }
            set
            {
                _RETURNPATH = value;
                DoOnChange("RETURNPATH", value);
            }
        }

        [Category("Movement")]
        public string PATH_TYPE
        {
            get { return _PATH_TYPE; }
            set
            {
                _PATH_TYPE = value;
                DoOnChange("PATH_TYPE", value);
            }
        }

        [Category("Movement")]
        public string WANDER_RADIUS
        {
            get { return _WANDER_RADIUS; }
            set
            {
                _WANDER_RADIUS = value;
                DoOnChange("WANDER_RADIUS", value);
            }
        }

        [Category("Movement")]
        public string WAYPOINT_DEVIATION
        {
            get { return _WAYPOINT_DEVIATION; }
            set
            {
                _WAYPOINT_DEVIATION = value;
                DoOnChange("WAYPOINT_DEVIATION", value);
            }
        }

        [Category("Movement")]
        public string QUICK_TURN
        {
            get { return _QUICK_TURN; }
            set
            {
                _QUICK_TURN = value;
                DoOnChange("QUICK_TURN", value);
            }
        }

        //-- Loot settings -->
        [Category("Loot")]
        public bool LOOT
        {
            get { return _LOOT; }
            set
            {
                _LOOT = value;
                DoOnChange("LOOT", value.ToString());
            }
        }

        [Category("Loot")]
        public bool LOOT_ALL
        {
            get { return _LOOT_ALL; }
            set
            {
                _LOOT_ALL = value;
                DoOnChange("LOOT_ALL", value.ToString());
            }
        }

        [Category("Loot")]
        public string LOOT_IN_COMBAT
        {
            get { return _LOOT_IN_COMBAT; }
            set
            {
                _LOOT_IN_COMBAT = value;
                DoOnChange("LOOT_IN_COMBAT", value);
            }
        }

        [Category("Loot")]
        public string LOOT_DISTANCE
        {
            get { return _LOOT_DISTANCE; }
            set
            {
                _LOOT_DISTANCE = value;
                DoOnChange("LOOT_DISTANCE", value);
            }
        }

        [Category("Loot")]
        public string LOOT_PAUSE_AFTER
        {
            get { return _LOOT_PAUSE_AFTER; }
            set
            {
                _LOOT_PAUSE_AFTER = value;
                DoOnChange("LOOT_PAUSE_AFTER", value);
            }
        }

        //-- Harvest options -->
        [Category("Harvesting")]
        public string HARVEST_DISTANCE
        {
            get { return _HARVEST_DISTANCE; }
            set
            {
                _HARVEST_DISTANCE = value;
                DoOnChange("HARVEST_DISTANCE", value);
            }
        }

        [Category("Harvesting")]
        public string HARVEST_WOOD
        {
            get { return _HARVEST_WOOD; }
            set
            {
                _HARVEST_WOOD = value;
                DoOnChange("HARVEST_WOOD", value);
            }
        }

        [Category("Harvesting")]
        public string HARVEST_HERB
        {
            get { return _HARVEST_HERB; }
            set
            {
                _HARVEST_HERB = value;
                DoOnChange("HARVEST_HERB", value);
            }
        }

        [Category("Harvesting")]
        public string HARVEST_ORE
        {
            get { return _HARVEST_ORE; }
            set
            {
                _HARVEST_ORE = value;
                DoOnChange("HARVEST_ORE", value);
            }
        }

        //-- Eggpet options -->
        [Category("Egg Pets")]
        public string EGGPET_ENABLE_CRAFT
        {
            get { return _EGGPET_ENABLE_CRAFT; }
            set
            {
                _EGGPET_ENABLE_CRAFT = value;
                DoOnChange("EGGPET_ENABLE_CRAFT", value);
            }
        }

        [Category("Egg Pets")]
        public string EGGPET_CRAFT_SLOT
        {
            get { return _EGGPET_CRAFT_SLOT; }
            set
            {
                _EGGPET_CRAFT_SLOT = value;
                DoOnChange("EGGPET_CRAFT_SLOT", value);
            }
        }

        [Category("Egg Pets")]
        public string EGGPET_ENABLE_ASSIST
        {
            get { return _EGGPET_ENABLE_ASSIST; }
            set
            {
                _EGGPET_ENABLE_ASSIST = value;
                DoOnChange("EGGPET_ENABLE_ASSIST", value);
            }
        }

        [Category("Egg Pets")]
        public string EGGPET_ASSIST_SLOT
        {
            get { return _EGGPET_ASSIST_SLOT; }
            set
            {
                _EGGPET_ASSIST_SLOT = value;
                DoOnChange("EGGPET_ASSIST_SLOT", value);
            }
        }

        [Category("Egg Pets")]
        public string EGGPET_CRAFT_RATIO
        {
            get { return _EGGPET_CRAFT_RATIO; }
            set
            {
                _EGGPET_CRAFT_RATIO = value;
                DoOnChange("EGGPET_CRAFT_RATIO", value);
            }
        }

        [Category("Egg Pets")]
        public string EGGPET_CRAFT_INDEXES
        {
            get { return _EGGPET_CRAFT_INDEXES; }
            set
            {
                _EGGPET_CRAFT_INDEXES = value;
                DoOnChange("EGGPET_CRAFT_INDEXES", value);
            }
        }


        //-- Log out and resurrect settings -->
        [Category("Logout")]
        public string LOGOUT_TIME
        {
            get { return _LOGOUT_TIME; }
            set
            {
                _LOGOUT_TIME = value;
                DoOnChange("LOGOUT_TIME", value);
            }
        }

        [Category("Logout")]
        public string LOGOUT_SHUTDOWN
        {
            get { return _LOGOUT_SHUTDOWN; }
            set
            {
                _LOGOUT_SHUTDOWN = value;
                DoOnChange("LOGOUT_SHUTDOWN", value);
            }
        }

        [Category("Logout")]
        public string LOGOUT_WHEN_STUCK
        {
            get { return _LOGOUT_WHEN_STUCK; }
            set
            {
                _LOGOUT_WHEN_STUCK = value;
                DoOnChange("LOGOUT_WHEN_STUCK", value);
            }
        }

        [Category("Logout")]
        public string CLOSE_WHEN_STUCK
        {
            get { return _CLOSE_WHEN_STUCK; }
            set
            {
                _CLOSE_WHEN_STUCK = value;
                DoOnChange("CLOSE_WHEN_STUCK", value);
            }
        }

        [Category("Logout")]
        public string RES_AUTOMATIC_AFTER_DEATH
        {
            get { return _RES_AUTOMATIC_AFTER_DEATH; }
            set
            {
                _RES_AUTOMATIC_AFTER_DEATH = value;
                DoOnChange("RES_AUTOMATIC_AFTER_DEATH", value);
            }
        }

        [Category("Logout")]
        public string MAX_DEATHS
        {
            get { return _MAX_DEATHS; }
            set
            {
                _MAX_DEATHS = value;
                DoOnChange("MAX_DEATHS", value);
            }
        }

        [Category("Logout")]
        public string MAX_UNSTICK_TRIALS
        {
            get { return _MAX_UNSTICK_TRIALS; }
            set
            {
                _MAX_UNSTICK_TRIALS = value;
                DoOnChange("MAX_UNSTICK_TRIALS", value);
            }
        }




        //-- Party Bot options  -->
        [Category("Party")]
        public string PARTY
        {
            get { return _PARTY; }
            set
            {
                _PARTY = value;
                DoOnChange("PARTY", value);
            }
        }

        [Category("Party")]
        public string PARTY_ICONS
        {
            get { return _PARTY_ICONS; }
            set
            {
                _PARTY_ICONS = value;
                DoOnChange("PARTY_ICONS", value);
            }
        }

        [Category("Party")]
        public string PARTY_INSTANCE
        {
            get { return _PARTY_INSTANCE; }
            set
            {
                _PARTY_INSTANCE = value;
                DoOnChange("PARTY_INSTANCE", value);
            }
        }

        [Category("Comms")]
        public string UDP_ENABLED
        {
            get { return _UDP_ENABLED; }
            set
            {
                _UDP_ENABLED = value;
                DoOnChange("UDP_ENABLED", value);
            }
        }

        [Category("Comms")]
        public string UDP_HOST
        {
            get { return _UDP_HOST; }
            set
            {
                _UDP_HOST = value;
                DoOnChange("UDP_HOST", value);
            }
        }

        [Category("Comms")]
        public string UDP_HOSTPORT
        {
            get { return _UDP_HOSTPORT; }
            set
            {
                _UDP_HOSTPORT = value;
                DoOnChange("UDP_HOSTPORT", value);
            }
        }

        [Category("Comms")]
        public string UDP_LOCALPORT
        {
            get { return _UDP_LOCALPORT; }
            set
            {
                _UDP_LOCALPORT = value;
                DoOnChange("UDP_LOCALPORT", value);
            }
        }

        [Category("Overrides")]
        public string STOP_TARGET_CLEARING
        {
            get { return _STOP_TARGET_CLEARING; }
            set
            {
                _STOP_TARGET_CLEARING = value;
                DoOnChange("STOP_TARGET_CLEARING", value);
            }
        }

        [Category("Debug")]
        public string Debug
        {
            get { return _DEBUG; }
            set { _DEBUG = value;
                DoOnChange("DEBUG", value);
            }
        }

        [Category("Debug")]
        public string DebugTarget
        {
            get { return _DEBUG_TARGET; }
            set { _DEBUG_TARGET = value;
                DoOnChange("DEBUG_TARGET", value);
            }
        }

        [Category("Debug")]
        public string DebugLoot
        {
            get { return _DEBUG_LOOT; }
            set { _DEBUG_LOOT = value;
                DoOnChange("DEBUG_LOOT", value);
            }
        }

        [Category("Debug")]
        public string DebugMacro
        {
            get { return _DEBUG_MACRO; }
            set { _DEBUG_MACRO = value;
                DoOnChange("DEBUG_MACRO", value);
            }
        }

        [Category("Debug")]
        public string DebugHarvest
        {
            get { return _DEBUG_HARVEST; }
            set { _DEBUG_HARVEST = value;
                DoOnChange("DEBUG_HARVEST", value);
            }
        }

        [Category("Debug")]
        public string DebugWaypoint
        {
            get { return _DEBUG_WAYPOINT; }
            set { _DEBUG_WAYPOINT = value;
                DoOnChange("DEBUG_WAYPOINT", value);
            }
        }

        [Category("Debug")]
        public string DebugAutosell
        {
            get { return _DEBUG_AUTOSELL; }
            set { _DEBUG_AUTOSELL = value;
                DoOnChange("DEBUG_AUTOSELL", value);
            }
        }

        public OnChangeOptionValueDelegate OnValueChanged = null;

        private void DoOnChange(string option, string value)
        {
            if (OnValueChanged != null) OnValueChanged(option, value);
        }

        public static MicroMacroOptions CreateFromXMLFile(string filename)
        {
            MicroMacroOptions result = new MicroMacroOptions();
            return result;
        }


    }
}