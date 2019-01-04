using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Contexts
{
    public class CommandStr
    {
        public const string CMD_GM = "gm@gmcommand";

        public const string LOG_FILE_NOT_FOUND = "log@fileNotFound";

        public const string USER_REGISTER = "createUser";

        public const string USER_LOGION = "login2";

        public const string USER_GETSEVERNAME = "getPlayersForLogin";

        public const string USER_QUIT = "quit";

        public const string USER_LOGOUT = "logout";

        public const string HEART_BEAT = "player@game";

        public const string HEART_BEAT_TEST = "player@xtest";

        public const string LOGIN_KEY_LOGIN = "login_user";

        public const string RECONNECT = "reconnect";

        public const string SEND_ERROR = "flash/write.action";

        public const string GET_DUO_WAN_SDK_INFO = "player@getDuowanSDKInfo";

        public const string PLAYER_MUSIC = "player@music";

        public const string PAY_360 = "pay@get360PayInfo";

        public const string FORCES_GET_FORCEINFO = "player@getForceInfo";

        public const string FORCES_SET_FORCEINFO = "player@setPlayerForce";

        public const string ROLE_GET_RANDOMNAMES = "player@getRandomNames";

        public const string ROLE_SET_PLAYERNAMES = "player@setPlayerNames";

        public const string ROLE_SET_PLAYERNAME_ANDPIC = "player@setPlayerNameAndPic";

        public const string ROLE_CHANGE_PLAYERNAME = "pay@changePlayerName";

        public const string PLAYER_GETPUSH_INFO = "player@getPushInfo";

        public const string ROLE_GETCANUP_INFO = "player@checkPlayerUpTo30";

        public const string ROLE_GET_LIST = "player@getPlayerList";

        public const string ROLE_GET_INFO = "player@getPlayerInfo";

        public const string ROLE_SET_NAME = "player@setPlayerName";

        public const string ROLE_CREATE = "player@createPlayer";

        public const string ROLE_DELETEPLAYER = "player@deletePlayer";

        public const string ROLE_RETRIEVE_PLAYER = "player@retrievePlayer";

        public const string ROLE_SELECT_DEFAULTPAY = "player@setDefaultPay";

        public const string CODE_GET_IMAGE = "code@getInputStream";

        public const string CODE_CHECK = "code@codeCheck";

        public const string CODE_TIMEOUT = "code@timeout";

        public const string MC_GET_BUILDING_INFO = "building@getBuildingInfo";

        public const string MC_GET_MAIN_CITY_INFO = "building@getMainCityInfo";

        public const string MC_UPGRADE_BUILDING = "building@upgradeBuilding";

        public const string KILL_BUILDING_GET_GOLD = "building@consCdRecover";

        public const string KILL_BUILDING_CD = "building@cdRecoverConfirm";

        public const string USE_TOKEN = "building@useFeatBuilding";

        public const string MAYDAY_GETTREASUREINFO = "mayDay@getTreasureInfo";

        public const string MAYDAY_PICKTREASURE = "mayDay@pickTreasure";

        public const string KILL_BUILDING_CD_COST = "building@cdRecover";

        public const string KILL_BANDIT = "building@killBandit";

        public const string DEVELOP_BUILDING = "building@openBluePrint";

        public const string USE_PICTURE_BUILDING = "building@consBluePrint";

        public const string KILLCD_PICTURE_BUILDING = "building@consCdRecoverConfirm";

        public const string BUILDING_CD_SPEED_UP = "building@cdSpeedUp";

        public const string START_AUTO_UP_BUILDING = "building@startAutoUpBuilding";

        public const string STOP_AUTO_UP_BUILDING = "building@stopAutoUpBuilding";

        public const string MAIN_CITY_FINAL_REBUILD_INVEST = "building@invest";

        public const string MAIN_CITY_FINAL_REBUILD_KONCK = "building@knock";

        public const string MAIN_CITY_FINAL_REBUILD_CONFIRM = "building@hallsReform";

        public const string CHAT_SEND = "chat@send";

        public const string CHAT_ADD_BLACKNAME = "chat@addBlackName";

        public const string GET_BLACKNAME_LIST = "chat@getBlackList";

        public const string REMOVE_BLACKNAME = "chat@removeBlackName";

        public const string JOIN_FORCE = "battle@joinForce";

        public const string WAR_PREPARE = "battle@battlePrepare";

        public const string WAR_BEGIN = "battle@battleStart";

        public const string LEAVE_WAR = "battle@leaveBattle";

        public const string OVER_WAR = "battle@quitBattle";

        public const string ADD_FORCE = "battle@addForcesBattle";

        public const string BATTLE_PERMIT = "battle@battlePermit";

        public const string USE_OFFICIAL_TOKEN = "battle@useOfficerTokenInBattle";

        public const string USE_GOLD_ORDER = "battle@useGoldOrder";

        public const string GET_CAMP_LIST = "battle@getCampList";

        public const string BATTLE_QUICK_BATTLE = "battle@quickBattle";

        public const string BATTLE_FIRE_CANNON = "battle@fireCannon";

        public const string BATTLE_DOUBLEREWARD = "battle@doubleReward";

        public const string BATTLE_GET_BATTLE_RESULT = "battle@getBattleResult";

        public const string BATTLE_DELETE_RESULT = "battle@deleteResult";

        public const string BATTLE_USE_STRATEGY = "battle@useStrategy";

        public const string BATTLE_AUTOBATTLE = "battle@autoBattle";

        public const string BATTLE_AUTOBATTLE_INFO = "battle@autoBatInfo";

        public const string BATTLE_STOP_AUTOBATTLE = "battle@stopAutoBattle";

        public const string BATTLE_GET_AUTOBATTLE = "battle@getAutoBattle";

        public const string BATTLE_CLOSE_AUTOBATTLE = "battle@closeAutoBattle";

        public const string BATTLE_GET_JXCC = "power@getJxccPowerInfo";

        public const string BATTLE_HELPINFO = "battle@helpInfo";

        public const string BATTLE_GET_QUITGENERAL = "battle@getQuitGeneral";

        public const string BATTLE_QUITBATTLE = "battle@quitBattle";

        public const string BATTLE_CHANGE_RDMODE = "battle@changeRdMode";

        public const string BATTLE_GET_ASSEMBLE_GENERAL = "battle@getAssembleGeneral";

        public const string BATTLE_ASSEMBLE_BATTLE = "battle@AssembleBattle";

        public const string WORLD_ASSEMBLE_BATTLE = "battle@AssembleBattleAll";

        public const string BATTLE_WORLD_ENEMY = "battle@youdi";

        public const string BATTLE_WORLD_ATTACK = "battle@chuji";

        public const string BATTLE_GET_COPYARMYCOST = "battle@getCopyArmyCost";

        public const string BATTLE_DOCOPYARMY = "battle@doCopyArmy";

        public const string BATTLE_GET_COVER_ATTACKCD = "battle@getCoverChujuCd";

        public const string BATTLE_GET_DO_ATTACKCD = "battle@doCoverChujuCd";

        public const string BATTLE_GET_COVER_ENEMYCD = "battle@getCoverYoudiCd";

        public const string BATTLE_GET_DO_ENEMYCD = "battle@doCoverYoudiCd";

        public const string BATTLE_GET_DARTATTACK_GENERALS = "battle@getTuJinGenerals";

        public const string BATTLE_DARTATTACK = "battle@tuJin";

        public const string BATTLE_USE_AUTOSTRATEGY = "battle@useAutoStrategy";

        public const string BATTLE_CANCEL_AUTOSTRATEGY = "battle@cancelAutoStrategy";

        public const string BATTLE_WATCH_BATTLE = "battle@watchBattle";

        public const string BATTLE_JOIN_BATTLE = "battle@joinBattle";

        public const string BATTLE_SET_CHANGE_BAT = "battle@setChangeBat";

        public const string BATTLE_USE_AUTO_BZ = "battle@useAutoBz";

        public const string GET_TASK_INFO = "task@getCurTaskInfo";

        public const string FINISHI_TASK = "task@finishTask";

        public const string GUILD_TASK = "task@guideUpdate";

        public const string TAVERN_GETGENERALS = "tavern@getGeneral";

        public const string TAVERN_REFRESHGENERAL = "tavern@refreshGeneral";

        public const string TAVERN_RECRUITGENERAL = "tavern@recruitGeneral";

        public const string TAVERN_LOCK = "tavern@lockGeneral";

        public const string TAVERN_UNLOCK = "tavern@unlockGeneral";

        public const string TAVERN_CDRECOVER = "tavern@cdRecover";

        public const string TAVERN_CDRECOVERCONFIRM = "tavern@cdRecoverConfirm";

        public const string TAVERN_GET_CANDROPGENERAL = "tavern@getCanDropGeneral";

        public const string TAVERN_DEPUTY_GENERAL = "general@deputyGeneral";

        public const string TAVERN_DEPUTY_SWITCH = "general@deputySwitch";

        public const string TAVERN_REPLACE_GENERAL = "general@replaceGeneral";

        public const string TAVERN_FLIP = "tavern@flip";

        public const string TAVERN_GET_DEIFY_GENERAL = "tavern@getDeifyGeneral";

        public const string TAVERN_DRINK = "tavern@drink";

        public const string OFFICER_GETOFFICERINFO = "officer@getOfficerInfo";

        public const string OFFICER_GETGENERALINFO = "officer@getGeneralInfo";

        public const string OFFICER_CHANGEGENERAL = "officer@changeGeneral";

        public const string GENERAL_GETGENERALINFP = "general@getGeneralInfo2";

        public const string GENERAL_START_RECRUITFORCES = "general@startRecruitForces";

        public const string GENERAL_STOP_RECRUITFORCES = "general@stopRecruitForces";

        public const string GENERAL_HIREGENERAL = "general@fireGeneral";

        public const string GENERAL_SINGLE_GETGENERALINFP = "general@getSingleGeneralInfo";

        public const string GENERAL_SINGLE_GETGENERAL_TIP = "general@getGeneralTips";

        public const string GENERAL_SINGLE_GETGENERAL_EQUIP_TIP = "general@getEquipTips";

        public const string GENERAL_BUY_EVOKEITEM = "evoke@buyZhugeWine";

        public const string GENERAL_GET_GENERALTREASURE_INFO = "general@getGeneralTreasureInfo";

        public const string GENERAL_CHANGE_GENERAL_TREASURE = "general@changeGeneralTreasure";

        public const string GENERAL_GET_GENERALSIMPLEINFO = "general@getGeneralSimpleInfo";

        public const string GENERAL_GET_GENERALSIMPLEINFO2 = "general@getGeneralSimpleInfo2";

        public const string GENERAL_CDVOVERCONFIRM = "general@cdRecoverConfirm";

        public const string GENERAL_CDRECOVER = "general@cdRecover";

        public const string GENERAL_AUTORECRUIT = "general@autoRecruit";

        public const string GENERAL_GET_WEAREQUIP = "equip@getWearEquip";

        public const string GENERAL_CHANGEEQUIP = "equip@changeEquip";

        public const string GENERAL_UNLOADEQUIP = "equip@unloadEquip";

        public const string GENERAL_UPGRADE_SUIT = "equip@upgradeSuit";

        public const string GENERAL_GET_WEAR_TREASURE = "general@getGeneralTreasureInfo";

        public const string GENERAL_CHANGE_TREASURE = "general@changeGeneralTreasure";

        public const string GET_SHOP_ITEMS = "store@getItem";

        public const string REFRESH_SHOP_ITEMS = "store@refreshItem";

        public const string BUY_ITEM = "store@buyItem";

        public const string LOCK_ITEM = "store@lockItem";

        public const string UNLOCK_ITEM = "store@unlockItem";

        public const string CD_RECOVER = "store@cdRecover";

        public const string CD_RECOVER_CONFIRM = "store@cdRecoverConfirm";

        public const string GET_QUALITY_TIPS = "store@getEquipSuitTipInfo";

        public const string EQUIP_BIND_EQUIP = "equip@bindEquip";

        public const string EQUIP_UNBIND_EQUIP = "equip@unbindEquip";

        public const string EQUIP_CANCEL_UNBIND_EQUIP = "equip@cancelUnbindEquip";

        public const string TECH_GET_TECH = "tech@getTech";

        public const string TECH_UPGRADETECH = "tech@upgradeTech";

        public const string TECH_CDRECOVER = "tech@cdRecover";

        public const string TECH_CDRECOVER_CONFORM = "tech@cdRecoverConfirm";

        public const string OPEN_TECH_GETINFO = "tech@getTechInfo";

        public const string TECH_ZHUZI = "tech@capitalInject";

        public const string TECH_STUDY = "tech@research";

        public const string GET_TECH_GOLD = "tech@cdRecover";

        public const string SURE_TECH_CD = "tech@cdRecoverConfirm";

        public const string OPEN_TECH_GET_DRAGON = "tech@getDragonTechInfo";

        public const string OPEN_TECH_OPEN_DRAGON = "tech@openDragonTech";

        public const string TECH_DECIDEOCCUPATION = "castle@decideOccupation";

        public const string TECH_LEARNSKILL = "castle@learnSkill";

        public const string TECH_GETWORKERTECHINFO = "castle@getWorkerTechInfo";

        public const string TECH_BUYTECHPOINT = "castle@buyTechPoint";

        public const string GET_WAR_SHOP_ITEMS = "supply@getInfo";

        public const string BUY_WAR_SHOP_ITEMS = "supply@buy";

        public const string RESFESH_WAR_SHOP_ITEMS = "supply@refresh";

        public const string GET_UPDATE_EQUIP_INFO = "equip@getEquipInfo";

        public const string SELECT_GEM_INFO = "equip@preMakeGem";

        public const string SPLIT_GEM_INFO = "equip@unMakeGem";

        public const string GEM_POLISH = "gem@gemPolish";

        public const string GEM_REFINE = "gem@gemRefine";

        public const string GEM_UPGRADE = "gem@gemUpgrade";

        public const string GEM_GOD_UPGRADE = "gem@godUpgrade";

        public const string GEM_SP_SLAUGHTER = "gem@spSlaughter";

        public const string BRILLIANT_EVOLUTION = "brilliant@evolution";

        public const string BRILLIANT_GOD_EVOLUTION = "brilliant@godEvolution";

        public const string BRILLIANT_BRILLAINT_UPGRADE = "brilliant@brilliantUpgrade";

        public const string BRILLIANT_REFINE = "brilliant@brilliantRefine";

        public const string GET_JINLIAN_TIMES = "event@getJinLianReward";

        public const string TAKE_UPDATE_EQUIP = "equip@updateEquip";

        public const string TAKE_UPDATE_EQUIP_TEN = "equip@updateEquipTen";

        public const string UPDATE_GEM_COMPOSE = "equip@makeGem";

        public const string UPDATE_GEM_ON = "equip@loadGem";

        public const string UPDATE_GEM_OFF = "equip@unloadGem";

        public const string UPDATE_PRE_GEM_ON = "equip@preLoadGem";

        public const string UPDATE_PRE_GEM_OFF = "equip@preUnloadGem";

        public const string GET_REFRESH_INFO = "quenching@openQuenching";

        public const string GET_EQUIPS_LIST = "quenching@getEquips";

        public const string REFRESH_EQUIPS = "quenching@quenchingEquip";

        public const string SET_REFRESH_REMIND = "quenching@remindSet";

        public const string GET_EQUIP_SKILL = "quenching@getRestoreInfo";

        public const string RECOVER_EQUIP_SKILL = "quenching@restoreSpecial";

        public const string GET_FREE_REFRESH_REWARD = "event@getXiLianReward";

        public const string GET_CHAPMAN_INFO = "trade@getTradeInfo";

        public const string BUY_CHAPMAN = "trade@invest";

        public const string GET_CHAPMAN_REWARD = "trade@getReward";

        public const string MODIFY_TRADE_TIPS = "trade@modifyTradeTips";

        public const string BUY_CHAPMAN_SILK = "trade@exchange";

        public const string GET_STORE_INFO = "equip@openStoreHouse";

        public const string BUY_STORE_SIZE = "equip@buySTSize";

        public const string SELL_ITEM = "equip@sellGoods";

        public const string USE_IRON_REWARD_TOKEN = "equip@useIronRewardToken";

        public const string GET_ALL_SKILL = "equip@getEquipSkillInfo";

        public const string USE_XILIAN_TOKEN = "equip@useXiLianToken";

        public const string USE_GEM_TOKEN = "equip@useGemToken";

        public const string USE_LIANBINGFU = "equip@useLianBingFu";

        public const string USE_XUN_ZHANG = "equip@useMedal";

        public const string GET_MEDAL_EQUIPS = "equip@medalEquips";

        public const string USE_TACTICAL = "strategics@openScroll";

        public const string USE_TREASURE_STONE = "equip@useTreasureStone";

        public const string USE_FEAT_TOKEN = "equip@useFeatToken";

        public const string USE_FEAT_ZROE = "equip@useFeatResetToken";

        public const string GET_STRATEGICS = "strategics@upgradeGetStrategics";

        public const string GET_STRATEGICS_LEVEL = "strategics@upgradeStrategicsInfo";

        public const string GET_REPO_INFO = "equip@openSTBack";

        public const string REPO_ITEM = "equip@buyBackGoods";

        public const string REPO_DRUG_GENERAL = "equip@getCanUseGeneral";

        public const string REPO_DRUG_USE = "equip@useOnGeneral";

        public const string REPO_CREATE_BUILDING_USE = "equip@useCreateBuilding";

        public const string REPO_EQUIPCOM_USE = "equip@compoundSuit";

        public const string REPO_EQUIPCOM_COMPOUND = "equip@doCompoundSuit";

        public const string REPO_SPLITEQUIP = "equip@deMountSuit";

        public const string REPO_SPLIT_GOLD = "equip@demountGold";

        public const string REPO_USE_ZIYUANLING = "equip@useResourceToken";

        public const string REPO_FUSE_USE = "equip@compoundProset";

        public const string REPO_FUSE_FUSEEQUIP = "equip@doCompoundProset";

        public const string REPO_FUSE_SPLITGOLD = "equip@demoutProsetGold";

        public const string REPO_FUSE_SPLIT = "equip@doDemoutProset";

        public const string REPO_MJML_USE = "equip@useMohistToken";

        public const string MERGE_TREASURE_INFO = "equip@mergeTreasureInfo";

        public const string MERGE_TREASURE = "equip@mergeTreasure";

        public const string USE_KING_DRINK = "equip@useKingDrink";

        public const string GET_FORCE_INFO = "battle@getPowerInfo";

        public const string SWITCH_FORCE_INFO = "battle@switchPowerInfo";

        public const string BATTLE_ARMY = "battle@battleArmies";

        public const string BATTLE_BUYBONUSNPC = "battle@buyBonusNpc";

        public const string RESET_BONUS_EXPEDITION = "power@resetBuyCount";

        public const string OPEN_CAOCAO_EXPEDITION = "kbtask@activateLv3";

        public const string BATTLE_GET_EXTRA_POWERINFO = "battle@getExtraPowerInfo";

        public const string BATTLE_BUY_POWER_EXTRA = "battle@buyPowerExtra";

        public const string INCENSE_GET_INCENSEINFO = "incense@getIncenseInfo";

        public const string INCENSE_DOINCENSE = "incense@doIncense";

        public const string INCENSE_INCENSEING = "incense@doWorship";

        public const string INCENSE_GET_FOLK_HOUSE = "incense@getFolkHouseReward";

        public const string OFFICER_GET_ALLOFFICER_BUILDING = "occupy@getAllOfficerBuilding";

        public const string OFFICER_GET_ALLOFFICER_BUILDINGINFO = "occupy@getOfficerBuildingInfo";

        public const string OFFICER_ATTACKlEGION = "occupy@attackLegion";

        public const string OFFICER_WAR_PREPARE = "occupy@battlePrepare";

        public const string OFFICER_WAR_START = "occupy@battleStart";

        public const string OFFICER_LEAVE_WAR = "occupy@leaveBattle";

        public const string OFFICER_QUIT_WAR = "occupy@quitBattle";

        public const string OFFICER_ADD_FORCE = "occupy@addForcesBattle";

        public const string SEARCH_GET_INFO = "world@getSearchInfo";

        public const string SEARCH_CONFIRM = "world@search";

        public const string SEARCH_GET_GENERAL = "world@chooseSearchGeneral";

        public const string SEARCH_GET_EVENT_REWARD = "world@searchEventConfirm";

        public const string SEARCH_REFRESH_CD = "world@endSearch";

        public const string SEARCH_CONFIRM_REFRESH_CD = "world@endSearchConfirm";

        public const string SEARCH_GET_OPERATION = "world@getOperations";

        public const string SEARCH_BUY_TIMES = "world@buySearchNum";

        public const string SEARCH_REFRESH = "world@getRefreshPrice";

        public const string SEARCH_REFRESH_INFO = "world@refreshSearchInfo";

        public const string INTERNAL_AFFAIRS_INFO = "general@getCivilInfo";

        public const string INTERNAL_AFFAIRS_START = "civil@startAffair";

        public const string INTERNAL_AFFAIRS_STOP = "civil@stopAffair";

        public const string INTERNAL_AFFAIRS_GET_REWARD = "civil@finishAffair";

        public const string INTERNAL_AFFAIRS_UPGRADE = "civil@upgradeAffair";

        public const string INTERNAL_AFFAIRS_GET_ALL_REWARD = "civil@finishAllAffair";

        public const string GET_CITIES = "world@enterWorldScene";

        public const string SAVE_LOC = "world@leaveWorldScene";

        public const string CITY_DETAIL_INFO = "world@getCityDetailInfo";

        public const string CITY_AFFAIR_INFO = "world@getCityEventPanel";

        public const string CITY_AFFAIR_DEAL = "world@dealCityEvent";

        public const string CITY_PLAYEREVENTPANAL = "world@getPEPanel";

        public const string CITY_DEALPALYEREVENT = "world@dealPlayerEvent";

        public const string CITY_DEALFORCEEVENT = "world@dealForceEvent";

        public const string WORLD_ARROW_TOWER_STATIC_INFO = "world@getArrowTowerStaticInfo";

        public const string GET_GRANARY = "battle@getGranaryCities";

        public const string WORLD_GET_BUILD_CITIES = "world@chooseBuildCity";

        public const string WORLD_BUILD_ROAD = "world@buildRoad";

        public const string WORLD_GET_BUILD_ROADS = "castle@chooseBuildChargeRoad";

        public const string WORLD_BUILD_CHARGE_ROAD = "castle@buildChargeRoad";

        public const string WORLD_GET_BUILD_CASTLE = "castle@chooseBuildBunker";

        public const string WORLD_GET_WORLD_TAGS = "world@getWorldTags";

        public const string WORLD_GET_ALL_CITIES = "world@getAllCities";

        public const string WORLD_GET_TAGS_INFO = "world@getTagsInfo";

        public const string WORLD_TAG_TAGS = "world@tagTags";

        public const string WORLD_REMOVE_TAG = "world@removeTag";

        public const string WORLD_DELETE_ALL_TAGS = "world@deleteAllTags";

        public const string WORLD_SILENT = "world@silent";

        public const string WORLD_NOSILENT = "world@noSilent";

        public const string WORLD_PHANTOM_INFO = "world@getTujinResult";

        public const string WORLD_SPECIALPHANTOM_INFO = "world@getSpecialPhantomInfo";

        public const string WORLD_GET_HBQ_RESULT = "world@getHBQResult";

        public const string WORLD_NEW_INVEST_COPPER = "nationTask@investCopper";

        public const string WORLD_NEW_INVEST_CD = "nationTask@fastRecover";

        public const string USE_KILL_TOKEN = "battle@useKillToken";

        public const string USE_PFCZ_TOKEN = "battle@usepfcz";

        public const string GET_REWARD_ZEROKILL = "world@getRewardWholePointKill";

        public const string HAVE_ZEROKILL = "rank@isWholeKill";

        public const string WORLD_MOVE_REQUEST = "world@getMoveResponse";

        public const string WORLD_REPAIR_MANZU_ROAD = "world@repairManzuRoad";

        public const string WORLD_MOVE = "world@move";

        public const string WORLD_AUTO_MOVE = "world@autoMove";

        public const string WORLD_AUTO_MOVE_STOP = "world@autoMoveStop";

        public const string WORLD_ORDER_OPERATION = "grouparmy@getOperations";

        public const string WORLD_MASS_APPLY = "grouparmy@getTeamInfo";

        public const string WORLD_LOOK_FOR = "grouparmy@getTeamInfo";

        public const string WORLD_FOLLOW = "grouparmy@followGeneral";

        public const string WORLD_STOP_FOLLOW = "grouparmy@stopFollow";

        public const string GET_STRATAGEM_ABLE = "cilviltrick@getpitchlocation";

        public const string USE_STRATAGEM = "cilviltrick@usetrick";

        public const string GET_QA_REWARD = "world@quizReward";

        public const string WORLD_ENDSEARCH = "world@endSearch";

        public const string WORLD_ENDSEARCHCONFIRM = "world@endSearchConfirm";

        public const string TREASURE_GET_TREASURES = "treasure@getTreasures";

        public const string DAILY_TASK = "task@getDailyBattleTaskInfo";

        public const string DAILY_TASK_REWARD = "task@receiveBattleTaskReward";

        public const string REMOVE_PROMPTS = "charge@noDisturb";

        public const string SPEND_PAY_INFO = "pay@getVipInfo";

        public const string SPEND_PAY_REWARD = "pay@handleVipPrivilege";

        public const string QQ_PAY = "yxTencent@buyGoods";

        public const string QQ_VIP_INFO = "pay@getYellowVipInfo";

        public const string QQ_VIP_REWARD = "pay@recvYellowVipReward";

        public const string POLITICS_GETEVENT_INFO = "politics@getEventInfo";

        public const string POLITICS_CHOOSEEVENT_OPTION = "politics@chooseEventOption";

        public const string POLITICS_GET_REWARD = "politics@getReward";

        public const string OFFICIAL_OPEN_RANK = "officer@getRankInfo";

        public const string OFFICIAL_GET_SALARY = "officer@getSalary";

        public const string SINGLED_AND_ATTACKCITY_GET_RANK = "rank@getTwoRankInfo";

        public const string SINGLED_AND_ATTACKCITY_GET_REWARD = "rank@getRankerReward";

        public const string GET_WORKER_INFO = "castle@getWorkerStatic";

        public const string ADDITION_RESOURCE_GETPRICE = "building@getAdditionPrice";

        public const string ADDITION_RESOURCE = "building@addBuildingAddition";

        public const string OPEN_MARKET_PANEL = "market@getMarketInfo";

        public const string BUSINESS_INFO = "trade@tradeInfo";

        public const string BUSINESS_UPGRADE = "trade@upTradesman";

        public const string BUSINESS_REFRESH = "trade@refresh";

        public const string BUSINESS_DO = "trade@doTrade";

        public const string MARKET_BUY_ITEM = "market@buyMarketProduct";

        public const string OPEN_BLACKMARKET_INFO = "market@getBlackMarketInfo";

        public const string CHANGE_BLACKMARKET_RESOURCE = "market@blackMarketTrade";

        public const string GET_CD_BLACKMARKET_PRICE = "market@cdRecover";

        public const string CD_BLACKMARKET = "market@cdRecoverConfirm";

        public const string OFFICER_BUILDING_OPERATION = "occupy@getOperation";

        public const string OFFICER_BUILDING_APPLY = "occupy@applyBuilding";

        public const string OFFICER_BUILDING_QUIT = "occupy@quitBuilding";

        public const string OFFICER_APPLY_INFO = "occupy@getApplyList";

        public const string OFFICER_APPLY_AGREE = "occupy@passApply";

        public const string OFFICER_APPLY_DISAGREE = "occupy@refuseApply";

        public const string OFFICER_APPLY_KICKOUT = "occupy@kickMember";

        public const string OFFICER_AUTO_AGREE = "occupy@changeAutoPass";

        public const string WORLD_ORDER_CONFIRM = "grouparmy@release";

        public const string WORLD_MASS_JION_GROUP = "grouparmy@joinGroupArmy";

        public const string WORLD_MASS_MEMBER = "grouparmy@getArmyMembers";

        public const string WORLD_MASS_QUIT = "grouparmy@quit";

        public const string WORLD_MASS_TRANSFER = "grouparmy@transferLeader";

        public const string WEAPON_OPEN_GETWEAPONINFO = "weapon@getWeaponInfo";

        public const string WEAPON_UPLEVEL = "weapon@upgrade";

        public const string WUGOD_WEAPON_UPLEVEL = "weapon@upgradeWudiWeapon";

        public const string WEAPON_UPLEVEL_ALL = "weapon@upgradeAll";

        public const string WEAPON_LOAD_ABLE_GEM = "weapon@getUnSetGems";

        public const string WEAPON_PRE_GEM_ON = "weapon@preLoadGem";

        public const string WEAPON_PRE_GEM_OFF = "weapon@preUnloadGem";

        public const string WEAPON_GEM_ON = "weapon@loadGem";

        public const string WEAPON_GEM_OFF = "weapon@unloadGem";

        public const string WEAPON_BUY_BLUEPRINT = "weapon@buyWeaponItem";

        public const string WEAPON_OPENSLOT = "weapon@openSlot";

        public const string WEAPON_GOD_CHANGE = "weapon@fuseWeapon";

        public const string WEAPON_GOD_UPLEVEL_ALL = "weapon@fuseWeapon";

        public const string WEAPON_GOD_GET_GENERAL = "weapon@getGenerals";

        public const string WEAPON_GOD_CHANGE_GENERAL = "weapon@equip";

        public const string WEAPON_START_REFORM = "weapon@startReform";

        public const string WEAPON_FINISH_REFORM = "weapon@finishReform";

        public const string KILLRANK_GET_RANKLIST = "killRank@getRankList";

        public const string KILLRANK_REWARD = "killRank@reward";

        public const string KILLRANK_GETBOXREWARD = "killRank@getBoxReward";

        public const string GIFI_GET_DAYGIFT = "gift@getDayGift";

        public const string GIFI_GET_DAYINFO = "tech@getNextTechInfo";

        public const string GIFT_MAIN_CITY_REBUILD_INFO = "gift@getMineDayGiftInfo";

        public const string GIFT_MAIN_CITY_REBUILD_REWARD = "gift@getMineDayGiftReward";

        public const string ZEROONLINE_GET_NUM = "gift@getOnlineGiftNumber";

        public const string ZEROONLINE_GET_GIFT = "gift@getOnlineGift";

        public const string GOLD_UP_BUILDING_CD = "building@freeCdRecover";

        public const string GOLD_UP_BUILDING = "building@freeCdRecoverConfirm";

        public const string IRONGEMORE_GETMINE_INFO = "mine@getMineInfo";

        public const string IRONGEMORE_RUSH = "mine@rush";

        public const string IRONGEMORE_ABANDON = "mine@abandon";

        public const string IRONGEMORE_MINE = "mine@mine";

        public const string OPEN_DINNER = "dinner@getDinnerInfo";

        public const string SELECT_WINE = "dinner@choiceLiqueurId";

        public const string START_DINNER = "dinner@haveDinner";

        public const string OPEN_BUILD_NATION_CELE = "kbtask@feastInfo";

        public const string GET_BUILD_NATION_CELE_REWARD = "kbtask@getCReward";

        public const string GET_MAIL_LIST = "mail@getMail";

        public const string GET_MAIL_BY_TYPE = "mail@getMailByType";

        public const string GET_MAIL_DELETED = "mail@getDeleteMail";

        public const string WRITE_MAIL = "mail@writeMail";

        public const string DELETE_MAIL = "mail@delete";

        public const string READ_MAIL = "mail@read";

        public const string SAVE_MAIL = "mail@save";

        public const string RECOVER_MAIL = "mail@retrieve";

        public const string DELETE_ALL_MAIL = "mail@thoroughDelete";

        public const string NATION_POWER_REWARD_INFO = "world@getRewardInfo";

        public const string GET_NATION_MATERIAL = "world@countryReward";

        public const string GET_GIFT_LIST = "gift@getGiftInfo";

        public const string GET_GIFT_ITEM = "gift@getGift";

        public const string INPUT_PWD_GET_GIFT = "gift@getGiftByCode";

        public const string GET_AUCTION_LIST = "auction@getCanAuctionTreasure";

        public const string GET_AUCTION_SIGN_LIST = "auction@getSigningTreasure";

        public const string SALE_AUCTION_ITEM = "auction@signTreasure";

        public const string CANCEL_AUCTION_ITEM = "auction@takeOffTreasure";

        public const string OPEN_AUCTION_INFO = "auction@getAuctionInfo";

        public const string BUY_AUCTION_ITEM = "auction@bidTreasure";

        public const string BUY_SELF_AUCTION_ITEM = "auction@AutoBidTreasure";

        public const string QULITYING_GETRANKINFO = "rankBat@getRankInfo";

        public const string QULITYING_GET_REWARDINFO = "rankBat@getRewardInfo";

        public const string QULITYING_DOREWARD = "rankBat@doReward";

        public const string QULITYING_CHANALLENGE_REWARDINFO = "rankBat@ChallengeRewardInfo";

        public const string QULITYING_BUYONETIME = "rankBat@buyOneTime";

        public const string QULITYING_GET_JIGENREWARD = "rankBat@getJifenReward";

        public const string KFWD_GETMATCHINFO = "kfwd@getMatchInfo";

        public const string KFWD_SIGNUP = "kfwd@signUp";

        public const string KFWD_SETFORMATION = "kfwd@setFormation";

        public const string KFWD_ENTER = "kfwd@enter";

        public const string KFWD_CHANGE_REWARDMODE = "kfwd@changeRewardMode";

        public const string KFWD_INSPRIRE = "kfwd@inspire";

        public const string KFWD_GETBOXINFO = "kfwd@getBoxInfo";

        public const string KFWD_RECEIVEBOX = "kfwd@receiveBox";

        public const string KFWD_GETRANKLIST = "kfwd@getRankList";

        public const string KFWD_PHANTOM_INFO = "kfworld@getTujinResult";

        public const string OPEN_SLAVE_GETINFO = "slave@getSlaveInfo";

        public const string INVEST_COPPER = "slave@investCopper";

        public const string HIT_UPLEVEL_CELL = "slave@updateLashLv";

        public const string HIT_SLAVE = "slave@lash";

        public const string BUILD_SLAVE_HOUSE = "slave@makeCell";

        public const string UP_LEVEL_CELL = "slave@updateLimbo";

        public const string SLAVE_ESCAPE = "slave@escape";

        public const string SLAVE_BUY_FREEDOM = "slave@freedom";

        public const string SLAVE_GET_REWARD = "slave@getReward";

        public const string SLAVE_PLAIN_WORK = "slave@plainWork";

        public const string SLAVE_FORCE_WORK = "slave@forceWork";

        public const string SLAVE_LASH_WORKER = "slave@lashPlayer";

        public const string OPEN_GUANYUAN_GETINFO = "battle@getCurrentTokenInfo";

        public const string REPLY_OFFICIAL_TOKEN = "battle@replyOfficerToken";

        public const string GET_NATION_TASK = "nationRank@getCurRankInfo";

        public const string GET_NATION_TASK_REWARD = "nationRank@getNationTaskReward";

        public const string UPGRADE_NATION_TASK = "nationRank@startNationTask";

        public const string BEFOR_NATION_TASK_CHOOSE = "vote@vote";

        public const string GET_NATION_TASK_VOTE = "vote@getVoteReward";

        public const string ARENA_MATCH_CLOSE_PANEL = "arenaMatch@closePanel";

        public const string ARENA_MATCH_SIGN_UP = "arenaMatch@signUp";

        public const string DRILL_GET_FREEMATCH = "ywMatch@getFreeMatchInfo";

        public const string DRILL_QUIT_FREEMATCH = "ywMatch@quitFreeMatch";

        public const string DRILL_CLOSE_NATIONMATCH = "ywMatch@closeMainPanel";

        public const string DRILL_CLOSE_FREEMATCH = "ywMatch@closeFreePanel";

        public const string DRILL_MATCH_SIGNUP = "ywMatch@signUp";

        public const string DRILL_GET_TASKINFO = "juben@getMultiJuBenTaskInfo";

        public const string DRILL_GET_TASKREWARD = "juben@getMultiJuBenReward";

        public const string DRILL_JB_LEAVE = "juben@leave";

        public const string DRILL_GETTUJINRESULT = "multiJuben@getTujinResult";

        public const string BATTLE_GET_TOKENINFO = "multiJuben@getOfficerTokenInfo";

        public const string BATTLE_GET_GOLDTOKENINFO = "multiJuben@getGoldTokenInfo";

        public const string START_BUILD_NATION_TASK = "kbtask@startTask";

        public const string GET_BUILD_NATION_TASK_INFO = "kbtask@getTaskInfo";

        public const string BUILD_NATION_TASK_INVEST = "kbtask@invest";

        public const string BUILD_NATION_TASK_REWARD = "kbtask@getTaskRewards";

        public const string GET_MORE_BUILD_NATION_TASK = "kbtask@getAfterWards";

        public const string WARLEGION_TEAM_CREATE = "team@teamCreate";

        public const string WARLEGION_GET_TEAMINFO = "team@getTeamInfo";

        public const string WARLEGION_JOINTEAM = "team@joinTeam";

        public const string WARLEGION_KICTOUTTEAM = "team@kickOutTeam";

        public const string WARLEGION_DISMISSTEAM = "team@dismissTeam";

        public const string WARLEGION_LEAVETEAM_ = "team@leaveTeam";

        public const string WARLEGION_TEAM_BATTLE = "team@teamBattle";

        public const string WARLEGION_GET_GENERALINFO = "team@getGeneralInfo";

        public const string WARLEGION_GET_BATCOST = "team@getBatCost";

        public const string WARLEGION_CLOSE_TEAMINFO = "team@closeTeamInfo";

        public const string WARLEGION_TEAM_INSPIRE = "team@teamInspire";

        public const string WARLEGION_TEAM_ORDER = "team@teamOrder";

        public const string WARLEGION_JOINTEAM_PHANTOM = "team@addPhantom";

        public const string KFWD_GET_PLAYER_INFO = "kfwd@getPlayerInfo";

        public const string KFWD_SIGN_UP = "kfwd@signUp";

        public const string KFWD_DOUBLE_REWARD = "kfwd@doubleReward";

        public const string KFWD_SYN_DATA = "kfwd@synData";

        public const string KFWD_GET_PLAYER_TICK_INFO = "kfwd@getPlayerTicketInfo";

        public const string KFWD_USE_TICK = "kfwd@useTicket";

        public const string KFWD_GET_TREASURE = "kfwd@getTreasure";

        public const string KFWD_USE_ST = "gameserver@useST";

        public const string KFWD_LOGIN = "gameserver@kfwdlogin";

        public const string KFWD_GET_MATCH_RT_INFO = "gameserver@getKfwdMatchRTInfo";

        public const string KFWD_GET_BATTLE_INI_INFO = "gameserver@getKfwdBattleIniInfo";

        public const string KFWD_GET_RANKING_INFO = "gameserver@getKfwdRankingInfo";

        public const string KFWD_GET_DAY_REWARD = "gameserver@getKfwdDayReward";

        public const string GET_INVEST_INFO = "nationRank@getInvestmentInfo";

        public const string START_INVEST = "nationRank@invenstCopper";

        public const string GET_INVEST_GOLD = "nationRank@investCdRecover";

        public const string KILL_INVEST_CD = "nationRank@investCdConfirm";

        public const string GET_DUEL_INFO = "duel@getDuelInfo";

        public const string GET_DUEL_GENERAL_INFO = "duel@getGeneralInfo";

        public const string GET_FM_TASK_INFO = "task@getfmTaskInfo";

        public const string GET_FM_TASK_REWARD = "task@getfmTaskReward";

        public const string GET_BUY_BARBARIAN = "world@getManzuShoumaiInfo";

        public const string BUY_BARBARIAN = "world@manzuShoumai";

        public const string START_BARBARIAN = "world@faDongmanzu";

        public const string GET_BUYBARBARIAN_GOLD = "world@getCoverManzuShoumaiCdCost";

        public const string KILL_BUYBARBARIAN_CD = "world@coverManzuShoumaiCd";

        public const string CHANGE_GENERAL_EQUIP = "equip@changAllEquip";

        public const string WANT_TO_LEAVE = "player@wantToLeave";

        public const string GAME_LEAVE = "player@leave";

        public const string ENTER_JUBEN_SCENE = "juben@enterJuBenScene";

        public const string GET_JUBEN_SCENE = "juben@getJuBenScene";

        public const string JUBEN_QUIT = "juben@quitJuBen";

        public const string JUBEN_MOVE = "juben@autoMoveJuBen";

        public const string JUBEN_MOVE_REQUEST = "juben@pleaseGiveMeAReply";

        public const string JUBEN_MOVE_STOP = "juben@autoMoveJuBenStop";

        public const string JUBEN_GET_CITY_INFO = "juben@getJuBenCityInfo";

        public const string JUBEN_GET_EVENT_INFO = "juben@getChoice";

        public const string JUBEN_MAKE_CHOICE = "juben@makeAChoice";

        public const string JUBEN_GET_RESULT = "juben@getJuBenReward";

        public const string JUBEN_BUY_STAR = "juben@buyStar";

        public const string GET_KF_GZ_BATTLE_INIINFO = "gameserver@getKfgzBattleIniInfo";

        public const string KF_GZ_USE_ST = "gameserver@kfgzUseST";

        public const string KF_GZ_DO_SOLO = "gameserver@doSolo";

        public const string KF_GZ_DO_RUSH = "gameserver@doRush";

        public const string KF_GZ_GET_RUSH_INFO = "gameserver@getCanRushInfo";

        public const string KF_GZ_FAST_ADD_TROOP_HP = "gameserver@fastAddTroopHp";

        public const string KF_GZ_GET_RETREAT_INFO = "gameserver@getRetreatInfo";

        public const string KF_GZ_DO_RETREAT = "gameserver@doRetreat";

        public const string KF_GZ_BUY_PHANTOM = "gameserver@buyPhantom";

        public const string KF_GZ_CALL_GENERAL_INFO = "gameserver@getCallGeneralInfo";

        public const string KF_GZ_CALL_GENERAL = "gameserver@callGeneral";

        public const string KF_MATCH_HEART = "gameserver@gzHeart";

        public const string KF_GZ_SET_AUTO_ATTACK = "gameserver@setAutoAttack";

        public const string KF_GZ_LEAVE_BATTLE_TEAM = "gameserver@leaveBattleTeam";

        public const string KF_GZ_CLEAR_SOLO_CD = "gameserver@clearSoloCd";

        public const string KF_GZ_DO_RUSH_IN_OFFICE_TOKEN_TEAM = "gameserver@doRushInOTTeam";

        public const string KF_GZ_USE_OFFICE_TOKEN = "gameserver@useOfficeToken";

        public const string KF_GZ_GET_OFFICE_TOKEN_TEAM_INFO = "gameserver@getOTTeamInfo";

        public const string KF_GZ_GET_GROUP_TEAM_INFO = "gameserver@getGroupTeamInfo";

        public const string KF_GZ_CLOSE_GROUP_TEAM = "gameserver@closeGroupTeam";

        public const string KF_GZ_CREATE_GROUP_TEAM = "gameserver@createGroupTeam";

        public const string KF_GZ_GET_ADD_GROUP_TEAM_INFO = "gameserver@getAddGroupTeamInfo";

        public const string NEW_KF_GZ_GET_ADD_GROUP_TEAM_INFO = "gameserver@getGroupGeneralInfo";

        public const string KF_GZ_ADDTO_GROUP_TEAM = "gameserver@addToGroupTeam";

        public const string KF_GZ_DISMISS_GROUP_TEAM = "gameserver@dismissGroupTeam";

        public const string KF_GZ_LEAVE_GROUP_TEAM = "gameserver@leaveGroupTeam";

        public const string KF_GZ_KICK_OUT_GROUP_TEAM = "gameserver@kickOutGroupTeam";

        public const string KF_GZ_GET_BAT_GROUP_TEAM = "gameserver@getGroupTeamBatCost";

        public const string KF_GZ_GROUP_TEAM_INSPIRE = "gameserver@groupTeamInspire";

        public const string KF_GZ_GROUP_TEAM_ORDER = "gameserver@groupTeamOrder";

        public const string KF_GZ_DO_BATTLE_GROUP_TEAM = "gameserver@doBattleGroupTeam";

        public const string KF_GZ_GET_GROUP_TEAM_CITY = "gameserver@getTeamSendCity";

        public const string KF_GZ_GROUP_TEAM_PHANTOM = "gameserver@addPhantom";

        public const string KF_GZ_CHOOSE_NPC_AI = "gameserver@chooseNpcAI";

        public const string KF_GZ_GET_BATTLE_CAMPLIST = "gameserver@getBattleCampList";

        public const string KF_GZ_GET_CITY_INFO = "kfworld@getCityInfo";

        public const string KF_GZ_GET_ALLY_INFO = "kfworld@getAllyInfo";

        public const string KF_GZ_GET_JIEBING_INFO = "kfworld@getJieBingInfo";

        public const string KF_GZ_SLAUGHTER = "gameserver@slaughter";

        public const string KF_GENERAL_START_MUBING = "kfgzGeneral@startMubing";

        public const string KF_GZ_GET_ALL_RANK_RES = "kfgz@getKfgzAllRankRes";

        public const string KF_GZ_SCHEDULE_INFO_LIST = "kfgz@scheduleInfoList";

        public const string KF_GZ_GET_PLAYER_RESULT = "kfgz@getRewardBoard";

        public const string KF_GZ_GET_REWARD = "kfgz@getReward";

        public const string TICKET_GET_MARKET = "tickets@getMarket";

        public const string TICKET_BUY = "tickets@buy";

        public const string KF_GZ_GET_END_REWARD_BOARD = "kfgz@getEndRewardBoard";

        public const string KF_GZ_GET_END_REWARD = "kfgz@getEndReward";

        public const string KFWORLD_GET_HBQ_RESULT = "kfworld@getHBQResult";

        public const string KFWORLD_GET_GOODSINFO = "goods@getGoodsInfo";

        public const string KFWORLD_GET_GOODS = "goods@getGoods";

        public const string KFWORLD_GET_CURGOODS = "kf@leaveForFood";

        public const string KFWORLD_ENTER = "kfworld@getWorldMap";

        public const string KFWORLD_MOVE = "kfworld@move";

        public const string KF_GZ_GENERAL_GET_INFO = "kfgzGeneral@getInfo";

        public const string KFGZ_SIGNUP = "kfgz@signUp";

        public const string KFGZ_LOGIN = "gameserver@kfgzlogin";

        public const string KFHZ_LOGIN = "kfhz@kfgzlogin";

        public const string ACTIVIYT_51ACTIVITY = "activity@get51activity";

        public const string ACTIVIYT_51REWARD = "activity@reward51Activity";

        public const string ACTIVITY_RECHARGE = "pay@getPayAcitivityInfo";

        public const string ACTIVITY_SPRINTLEVEL = "activity@getLvExpActivity";

        public const string ACTIVITY_SPRINTLEVEL_REWARD = "activity@rewardLvExpActivity";

        public const string ACTIVITY_DUANWUJIE = "activity@getDragonInfo";

        public const string ACTIVITY_DUANWUREWARD = "activity@useDragon";

        public const string ACTIVITY_REFRESH = "activity@quenching";

        public const string ACTIVITY_IRON = "activity@getIronInfo";

        public const string ACTIVITY_IRON_REWARD = "activity@useIron";

        public const string COST_GET_TICKET = "pay@getTicketAcitivityInfo";

        public const string GET_DSTQ_INFO = "activity@getDstqInfo";

        public const string ACTIVITY_COMMON = "event@getInfo";

        public const string ACTIVITY_COMMON_MORE = "event@getInfo2";

        public const string ACTIVITY_COMMON_REWARD = "event@getReward";

        public const string ACTIVITY_PRISON_LASH = "event@lashSlave";

        public const string ACTIVITY_MIDAUTUMN_BIG_REWARD = "event@getBigGift";

        public const string ACTIVITY_NATIONAL_DAY_BIG_REWARD = "event@getNationalDayBigGift";

        public const string ACTIVITY_NATIONAL_DAY_COIN_REWARD = "world@getExtraInfo";

        public const string ACTIVITY_NATIONAL_DAY_GET_COIN_REWARD = "world@getExtraReward";

        public const string ACTIVITY_360_PRIVILEGE = "activity@get360PrivilegeInfo";

        public const string ACTIVITY_360_PRIVILEGE_REWARD = "activity@recv360Privilege";

        public const string ACTIVITY_360_PRIVILEGE_SPEED = "activity@get360PriviSpeedUpInfo";

        public const string ACTIVITY_360_PRIVILEGE_SPEED_REWARD = "activity@recv360SpeedUpPrivi";

        public const string ACTIVITY_GET_IRON_GIVE_BONUS = "event@getIronGiveBonus";

        public const string ACTIVITY_METEOR_INCENSE = "meteor@incense";

        public const string ACTIVITY_BOAT_BUYSAILOR = "activity@buySailor";

        public const string ACTIVITY_BOAT_HITDRUM = "activity@hitDrum";

        public const string ACTIVITY_BOAT_CLEARSTATE = "activity@clearState";

        public const string ACTIVITY_BOAT_GETREWARD = "activity@getReward";

        public const string ACTIVITY_BOAT_STARTMATCH = "activity@startMatch";

        public const string ACTIVITY_BOAT_AUTOFLIP = "activity@autoFlip";

        public const string ACTIVITY_BOAT_UNWATCH = "activity@unwatch";

        public const string ACTIVITY_BOAT_GOBACK = "activity@goBack";

        public const string ACTIVITY_HAWK_FEAT = "activity@getHawkFeat";

        public const string ACTIVITY_NEWYEARBAG_WORSHIPGOD = "nyRedPaper@worshipGod";

        public const string ACTIVITY_NEWYEARBAG_OPENONEBAG = "nyRedPaper@openOne";

        public const string ACTIVITY_NEWYEARBAG_OPENONEFREEBAG = "nyRedPaper@welfareOpen";

        public const string ACTIVITY_NEWYEARBAG_RECVEXTRAREWARD = "nyRedPaper@recvExtraReward";

        public const string ACTIVITY_NEWYEARBAG_RANKINFO = "nyRedPaper@getRankList";

        public const string ACTIVITY_JUESTONE_GETREWARD = "jueStone@getReward";

        public const string ACTIVITY_GATHERMINE_DIG = "event@digIron";

        public const string ACTIVITY_GATHERMINE_BUYIRONPRISONER = "event@buyIronPrisoner";

        public const string ACTIVITY_GATHERMINE_METEOR = "event@openIronMeteor";

        public const string JUBEN_INFO = "juben@getJuBenList";

        public const string JUBEN_PERMIT = "juben@juBenPermit";

        public const string ENTER_PERSON_SCRIPT = "juben@enterJuBenQuick";

        public const string DAILY_OCCUPY_GET_INFO = "scoreRank@getRankInfo";

        public const string DAILY_OCCUPY_GET_BOX_REWARD = "scoreRank@getBoxReward";

        public const string DAILY_OCCUPY_GET_RANK_REWARD = "scoreRank@getRankReward";

        public const string FEAT_LIST_GET_INFO = "feat@getFtRankInfo";

        public const string FEAT_GET_PLAYERRANKLIST_INFO = "feat@getPlayerRank";

        public const string FEAT_LIST_GET_BOX_REWARD = "feat@getBoxReward";

        public const string FEAT_LIST_GET_RANK_REWARD = "feat@getRankReward";

        public const string FEAT_LIST_GO_PARTY = "feat@getDrinkReward";

        public const string FEAT_LIST_GET_CHOSEN_REWARD = "feat@getChosenReward";

        public const string FEAT_LIST_GET_HAMMER_REWARD = "feat@getHammer";

        public const string OPEN_OFFBARBAR_GETINFO = "battle@getReplyMWLInfo";

        public const string REPLY_OFFBARBAR = "battle@replyManWangLing";

        public const string NATION_GET_NATION_INFO = "nation@getNationInfo";

        public const string NATION_OPEN_TRY = "nation@openTry";

        public const string NATION_GET_TRY_INFO = "nation@getTryInfo";

        public const string NATION_GET_REWARD = "nation@getReward";

        public const string NATION_UPDATE_KING_NOTICE = "king@updateKingNotice";

        public const string NATION_GET_KING_NOTICE = "king@getKingNoticeInfo";

        public const string OPEN_WARLOCKINFO = "phantom@getPhantomPanel";

        public const string GETWIAZRDDETAIL = "phantom@getWiazrdDetail";

        public const string UPDATEWARLOCK = "phantom@buildWorkShop";

        public const string UPGRADEWIAZRD = "phantom@upgradeWizard";

        public const string RECEIVEWARLOCK = "phantom@gainExtraNum";

        public const string RESEARCHWARLOCK = "phantom@gainPhantom";

        public const string RESEARCHRECEIVE = "phantom@gainDoneNum";

        public const string STOP_WIZARD = "phantom@stopWizard";

        public const string PHANTOM_INVEST_COPPER = "phantom@investCopper";

        public const string PHANTOM_TOTAL_START = "phantom@totalStart";

        public const string PHANTOM_TOTAL_STOP = "phantom@totalStop";

        public const string PHANTOM_TOTAL_GAIN_DONE = "phantom@totalGainDone";

        public const string GET_PROTECT_BARBARINFO = "protect@getProtectInfo";

        public const string GET_PROTECT_REWARD = "protect@getProtectRewards";

        public const string OPEN_EXPEDITION_GUILD = "battle@getPowerGuide";

        public const string GET_CURRENT_EXPEDITION_GUILD = "battle@getCurrentGuide";

        public const string GET_GOLD_ORDER_INFO = "battle@getGoldOrderInfo";

        public const string REPLY_GOLD_ORDER = "battle@replyGoldOrder";

        public const string KFGZ_USE_ORDER_TOKEN = "gameserver@useOrderToken";

        public const string KFGZ_GET_ORDER_TEAM_INFO = "gameserver@getOrderTeamInfo";

        public const string KFGZ_DO_RUSH_IN_ORDER_TEAM = "gameserver@doRushInOrderTeam";

        public const string GET_COURTESY_INFO = "courtesy@getPanel";

        public const string GET_COURTESY_EVENT = "courtesy@handleEvent";

        public const string GET_COURTESY_REWARD = "courtesy@getLiYiDuReward";

        public const string SMITHY_GET_INFO = "blacksmith@getBlacksmithInfo";

        public const string SMITHY_UPGRADE = "blacksmith@updateBlackSmith";

        public const string SMITHY_DISSOLVE = "blacksmith@dissolve";

        public const string SMITHY_UPGRADE_BLACKSMITH = "blacksmith@updateSmith";

        public const string SMITHY_INVEST_COPPER = "blacksmith@investCopper";

        public const string SELECT_WAR_CITYID = "huizhan@chooseCity";

        public const string SELECT_WAR_DECLARE = "huizhan@declareWar";

        public const string OPEN_BATTLE_LETTER_INFO = "huizhan@getBattleLetterInfo";

        public const string ACCEPT_BATTLE_LETTER = "huizhan@acceptBattle";

        public const string CANCEL_BATTLE_LETTER = "huizhan@rejectBattle";

        public const string GET_HUIZHAN_INFO = "huizhan@getHuiZhanGatherInfo";

        public const string JOIN_HUIZHAN_WAR = "huizhan@joinHuiZhan";

        public const string OPEN_HUIZHAN_INFO = "huizhan@getHuiZhanInfo";

        public const string GET_HUIZHAN_REWARDS = "huizhan@receiveHuizhanRewards";

        public const string CHOOSE_HUIZHAN_CITY = "huizhan@preChooseCity";

        public const string OPEN_HZSUPPORT_TOKEN = "huizhan@getHzSupportTokenInfo";

        public const string REPLY_HZSUPPORT_TOKEN = "battle@replyHzSupportToken";

        public const string FULL_FESTIVAL_MATERIAL = "rank@investyx";

        public const string KFZB_GET_SIGNUP_PANEL = "kfzb@getSignUpPanel";

        public const string KFZB_SIGN_UP = "kfzb@signUp";

        public const string KFZB_GET_TABLE = "kfzb@get16Table";

        public const string KFZB_GET_SUPPORT_PANEL = "kfzb@getSupportPanel";

        public const string KFZB_SUPPORT = "kfzb@support";

        public const string KFZB_WAIT = "kfzb@giveWay";

        public const string KFZB_VIEW_BATTLE = "kfzb@viewBattle";

        public const string KFZB_SELF_VIEW_BATTLE = "kfzb@competitorViewBattle";

        public const string KFZB_SYN_DATA = "kfzb@synData";

        public const string KFZB_GET_TICKETS = "kfzb@getTickets";

        public const string KFZB_GET_SUP_TICKETS = "kfzb@getSupTickets";

        public const string KFZB_BUY_FLOWER = "kfzb@buyFlower";

        public const string KFZB_LOGIN = "gameserver@kfzblogin";

        public const string KFZB_GET_KFZB_MATCH_RT_INFO = "gameserver@getKfzbMatchRTInfo";

        public const string KFZB_GET_KFZB_BATTLE_IN_INFO = "gameserver@getKfzbBattleIniInfo";

        public const string KFZB_USE_KFZB_ST = "gameserver@useKfzbST";

        public const string KFZB_USE_STRATAGEM = "kfzb@useStratagem";

        public const string KFZB_GET_REWARD_INFO = "kfzb@getRewardInfo";

        public const string GET_CIVI_GENERAL = "kfzb@getStratagems";

        public const string KFZB_GET_CURR_CHAMPION_INFO = "kfzb@getCurrChampionInfo";

        public const string KFZB_GET_KFELITE_CHAMPION_IFNO = "kfzb@getKfeliteChampionInfo";

        public const string KFZB_CELEBRATE_CHAMPION = "kfzb@celebrateChampion";

        public const string KFZB_GET_16REWARD = "kfzb@get16Reward";

        public const string KFZB_DICE = "gameserver@dice";

        public const string KFZB_GETGLISTINZB = "tavern@getGlistInZb";

        public const string GET_GEMSHOP_INFO = "diamondshop@getInfo";

        public const string BUILD_GEMSHOP = "diamondshop@addNewShop";

        public const string UPLEVEL_GEMSHOP = "diamondshop@upgradeShop";

        public const string EXCHANGE_GEM = "diamondshop@exchange";

        public const string FARM_GET_INFO = "farm@getFarmInfo";

        public const string FARM_GET_LB_INFO = "farm@getLblInfo";

        public const string FARM_START = "farm@start";

        public const string FARM_STOP = "farm@stop";

        public const string FARM_DONATION = "farm@investFarm";

        public const string FARM_START_ALL = "farm@startAll";

        public const string FARM_STOP_ALL = "farm@stopAll";

        public const string FARM_GET_DONATION_INFO = "world@getFarmCityInfo";

        public const string FARM_KILL_CD_GOLD = "farm@getRecoverCostGold";

        public const string FARM_KILL_CD = "farm@recoverGold";

        public const string FARM_REWARD = "farm@getReward";

        public const string FARM_FAST_FINISH = "farm@fastFarm";

        public const string BANQUET_GETMOVEINFO = "feast@getFeastInfo";

        public const string BANQUET_BUY_DRINK = "feast@buyDrink";

        public const string BANQUET_BUY_CARD = "feast@buyCard";

        public const string BANQUET_GET_ROOM_INFO = "feast@getRoomInfo";

        public const string BANQUET_BUY_LVBU_CARD = "feast@buyLvbuCard";

        public const string BANQUET_USE_LVBU_CARD = "feast@useLvbuCard";

        public const string BANQUET_SPECIAL_DRINK = "feast@specialDrink";

        public const string BANQUET_GET_SPECIAL_FEAST_INFO = "feast@getSpecialFeastInfo";

        public const string BANQUET_EXCHANGE_CARD = "feast@exchangeCard";

        public const string GET_IRONGIFT_REWARD = "event@getReward";

        public const string DECORATE_TREE = "event@decorateTree";

        public const string YAOYAO_CHRISTMAS = "event@yaoYiYao";

        public const string CHRISTMAS_BIG_REWARD = "event@getChristmasBigGift";

        public const string SUMMON_NIAN_MONSTER = "event@buyBeast";

        public const string NIAN_MONSTER_KILL_CD = "event@recoverBeastCd";

        public const string NY_GREETING_BIG_REWARD = "event@getBaiNianBigGift";

        public const string GET_NEWYEAR_WISH_BIG_REWARD = "event@getWishBigGift";

        public const string GET_NEWYEAR_WISH_BIG_REWARD2 = "event@getWishBigGift2";

        public const string GET_LOGIN_REWARD_INFO = "player@getLoginRewardInfo";

        public const string GET_LOGIN_REWARD = "player@getLoginReward";

        public const string RED_BAG_GET_INFO = "event@getInfo";

        public const string RED_BAG_GET_REWARD = "event@getReward";

        public const string BUY_FESTIVAL_NUM = "event@buyLantern";

        public const string BUY_NEW_FESTIVAL_NUM = "event@buyNewLantern";

        public const string EAT_FESTIVAL_NUM = "event@eatLantern";

        public const string EAT_NEW_FESTIVAL_NUM = "event@newLanternEat2017";

        public const string start_Eat_NewLantern = "event@startEatNewLantern";

        public const string EAT_GOLD_SOAPBALL = "event@eatGoldSoupball";

        public const string BUY_GOLD_SOUPBALL = "event@buyGoldSoupball";

        public const string GET_FESTIVAL_END_REWARD = "event@getLanternBigGift";

        public const string GET_NEW_FESTIVAL_END_REWARD = "event@getNewLanternBigGift";

        public const string IRON_TURN_TABLE_ROTATE = "event@IronRotaryEventRotate";

        public const string IRON_TURN_TABLE_BUY = "event@buyIronRotaryEventCount";

        public const string IRON_TURN_TABLE_REWARD = "event@IronRotaryEventReward";

        public const string GEM_TURN_TABLE_ROTATE = "event@GemRotaryEventRotate";

        public const string GEM_TURN_TABLE_BUY = "event@buyGemRotaryEventCount";

        public const string GEM_TURN_TABLE_REWARD = "event@GemRotaryEventReward";

        public const string GET_PERSON_REWARD = "rank@getIndivReward";

        public const string KILL_TASK_PERSON = "rank@fastIndivTask";

        public const string CELL_TRY = "slave@useInTaril";

        public const string CELL_FREE = "slave@freeInTaril";

        public const string START_AUTO_BATTLE = "battle@startAutoBattle";

        public const string STOP_AUTO_BATTLE = "battle@stopAutoBattle";

        public const string GET_AUTO_BATTLE_DETAIL = "battle@getAutoBattleDetail";

        public const string CHANGE_AUTO_BATTLE_MODE = "battle@changeAutoBattleMode";

        public const string AUTO_BATTLE_SIMPLE_INFO = "battle@getAutoBattleSimpleInfo";

        public const string CHANGE_REPLY_TOKEN = "battle@changeReplyToken";

        public const string CHANGE_AUTO_DEF_MODE = "battle@setDefend";

        public const string GET_BOUNS_NPC_INFO = "battle@getDetailedBonusNpcInfo";

        public const string GET_BOUNS_NPC_REWARD = "battle@recvBonusReward";

        public const string CHANGE_GODKNIFE = "event@swordChanllenge";

        public const string CHANGE_AGAIN_GODKNIFE = "event@sword2Chanllenge";

        public const string SWORDEXP_GODKNIFE = "event@swordGoldExp";

        public const string GET_GODKNIFE_BUFF = "event@getSwordBuff";

        public const string GEM_KIT_GET_KIT_INFO = "gemKit@getKitInfo";

        public const string GEM_KIT_OPEN_KIT = "gemKit@openKit";

        public const string GEM_KIT_RECV_KIT = "gemKit@recvKit";

        public const string GEM_KIT_RECV_GEM = "gemKit@recvGem";

        public const string GEM_KIT_CONTINUE_COLLECT = "gemKit@continueCollect";

        public const string ANCIENT_CASTLE_CHOOSE = "activity@chooseAdventure";

        public const string ANCIENT_CASTLE_ENTER = "activity@startAdventure";

        public const string ANCIENT_CASTLE_DICE = "activity@throwDice";

        public const string ANCIENT_CASTLE_MOVE = "activity@move";

        public const string ANCIENT_CASTLE_QUIT = "activity@quitAdventure";

        public const string ANCIENT_CASTLE_PROGRESS_REWARD = "activity@getAllFinalBox";

        public const string ANCIENT_CASTLE_MAP_REWARD = "activity@getMapFinalBox";

        public const string ANCIENT_CASTLE_RESTART = "activity@restartMap";

        public const string ANCIENT_CASTLE_BUY_TIME = "activity@buyAncientTime";

        public const string ANCIENT_OPEN_MAP = "activity@openMap";

        public const string KONCK_GEM_STONE_MINE = "event@knockGemStoneMine";

        public const string PICK_UP_GEM = "event@pickUpGem";

        public const string GET_GAME_LOBBY_360_INFO = "activity@get360GameHallInfo";

        public const string GET_GAME_LOBBY_360_REWARD = "activity@recv360GameHallRewards";

        public const string BAKA_ZIZI_GET_IRON = "event@receivedMrFoolIron";

        public const string BAKA_ZIZI_GET_BOX = "event@receivedMrFoolBigReward";

        public const string BAKA_ZIZI_BUY_BOX = "event@receivedMrFoolByGold";

        public const string BAKA_ZIZI_START_WORK = "event@mrFoolWork";

        public const string ADVANCED_BAKA_ZIZI_GEM_REWARD = "event@getAdvancedMrFoolGem";

        public const string ADVANCED_BAKA_ZIZI_BOX_REWARD = "event@getAdvancedMrFoolBox";

        public const string PRIVILEGE_37WAN_INFO = "activity@get37WanVipRewardInfo";

        public const string PRIVILEGE_37WAN_REWARD = "activity@recv37WanVipReward";

        public const string PRIVILEGE_BAIDU_INFO = "player@getBaiduMemPanel";

        public const string PRIVILEGE_BAIDU_REWARD = "player@getBaiduMemReward";

        public const string GET_ACCUM_PAY_INFO = "playerTx@getTxTreasureInfo";

        public const string GET_ACCUM_PAY_REWARD = "playerTx@recvTxTreasure";

        public const string BATTLE_SELECT_MATRIX = "battle@selectMatrix";

        public const string MINE_GET_IRON = "event@receivedBombIron";

        public const string MINE_GET_BOX = "event@receivedIronMineBox";

        public const string MINE_BOMB_BUY = "event@buyBomb";

        public const string MINE_BOMB_IRON = "event@bombIronMine";

        public const string MINE_KEY_BUY = "event@buyIronMineKey";

        public const string MINE_OPEN_BOX = "event@getReward";

        public const string MINE_KILL_CD = "event@clearIronMineRecoveryCd";

        public const string STEEL_BOMB_BUY = "gangMine@buyBomb";

        public const string STEEL_BOMB = "gangMine@bomb";

        public const string STEEL_GET_IRON = "gangMine@recvReward";

        public const string STEEL_WEAPON_LEVELUP = "gangMine@upgradeWeapon";

        public const string STEEL_WEAPON_START_LEVELUP = "gangMine@startUpgrade";

        public const string STEEL_SWITCH_WEAPON = "gangMine@switchWeapon";

        public const string GET_EVERYDAY_TRAIN_REWARD = "world@getDrillReward";

        public const string GET_JOYVIP_INFO = "activity@get84joyVipRewardInfo";

        public const string PRIVILEGE_JOYVIP_REWARD = "activity@recv84joyVipReward";

        public const string GET_YXIFENGVIP_INFO = "activity@getYxVipRewardInfo";

        public const string PRIVILEGE_YXIFENGVIP_REWARD = "activity@getYxVipReward";

        public const string GET_NEW_MIDAUTUMN_INFO = "event@getInfo";

        public const string GET_NEW_MIDAUTUMN_CAKE_REWARD = "activity@getMoonReward";

        public const string GET_NEW_MIDAUTUMN_BIG_REWARD = "activity@getFinalMoonReward";

        public const string GET_NEW_MIDAUTUMN_BUY_RABBITS = "activity@buyRabbits";

        public const string GET_THREE_VISITS_INFO = "event@getInfo";

        public const string CHOOSE_THREE_VISITS_TASK = "event@choiceTask";

        public const string GET_THREE_VISITS_BOX = "event@getReward";

        public const string GET_THREE_VISITS_REWARD = "event@getVisitPieceReward";

        public const string GET_THREE_VISITS_KILL_CD = "event@confirmVisitCd";

        public const string GET_THREE_VISITS_BUY_TASK = "event@choiceTaskAgain";

        public const string SEVENE_MH_IMPACT = "event@impact";

        public const string SEVENE_MH_PICK_UP_PHANTOM = "event@pickUpPhantom";

        public const string SEVENE_MH_GIVE_UP_GAIN_AGAIN = "event@giveUpGainAgain";

        public const string GET_CELE_INFO = "player@getCeleInfo";

        public const string JOIN_CELE_INFO = "player@joinCeleDinner";

        public const string GET_CELE_REWARD = "player@celebrate";

        public const string JOIN_MAINCITY_PARTY_INFO = "dinner@getHallsDinnerInfo";

        public const string START_MAINCITY_PARTY = "dinner@haveHallsDinner";

        public const string GET_CITY_COMBO_REWARD = "world@getComboReward";

        public const string CITY_COMBO_START = "world@startCombo";

        public const string GET_DISCOUNT_INFO = "player@getDiscountInfo";

        public const string BUY_DISCOUNT_GOODS = "player@buyDiscountGoods";

        public const string EVOKE_OPEN_EVOKE = "evoke@openEvoke";

        public const string EVOKE_GOLD_EVOKE = "evoke@goldEvoke";

        public const string EVOKE_GEM_EVOKE = "evoke@gemEvoke";

        public const string EVOKE_STONE_EVOKE = "evoke@stoneEvoke";

        public const string EVOKE_USE_BMT = "evoke@useBmt";

        public const string EVOKE_GET_ALL_EVOKE_INFO = "evoke@getAllEvokeInfo";

        public const string KFHZ_SIGN_UP = "kfhz@signUp";

        public const string KFHZ_PEROAER_INFO = "kfhz@prepareInfo";

        public const string KFHZ_SCHEDULE_INFO_LIST = "kfhz@scheduleInfoList";

        public const string KFHZ_GET_REWARD_INFO = "kfhz@getRewardInfo";

        public const string KFHZ_GET_TASK_INFO = "kfhz@getTaskInfo";

        public const string KFHZ_GET_REWARD = "kfhz@getReward";

        public const string KFHZ_GET_TASK_REWARD = "kfhz@getTaskReward";

        public const string KFHZ_GET_TASK_S_INFO = "kfhz@getTaskSInfo";

        public const string KFHZ_GET_INDIV_TASK_INFO = "kfhz@getIndivTaskInfo";

        public const string KFHZ_GET_INDIV_TASK_REWARD = "kfhz@getIndivTaskReward";

        public const string GEM_SHOP_SUPPLY_GOODS = "diamondshop@complementGood";

        public const string SPECIAL_TASK_GET_SIMPLE_INFO = "special@getSpecialSInfo";

        public const string SPECIAL_TASK_GET_DETAIL_INFO = "special@getSpecialDInfo";

        public const string SPECIAL_TASK_GET_REWARD = "special@getTaskReward";

        public const string SPECIAL_TASK_GET_WORLD_INVEST_INFO = "special@getInvestInfo";

        public const string SPECIAL_TASK_INVEST = "special@investMoney";

        public const string SPECIAL_TASK_INVEST_RECOVER = "sepcial@investRecover";

        public const string GET_LEAGUE_INFO = "world@getLeagueInfo";

        public const string GET_ATT_TOKEN_INFO = "battle@getAttDefToken";

        public const string REPLY_ATT_TOKEN = "battle@replyAttDefToken";

        public const string FACTION_CHANGE_CANCEL_BETRAY = "event@cancelBetray";

        public const string FACTION_CHANGE_GET_BETRAYER_LIST = "event@getBetrayersList";

        public const string FACTION_CHANGE_GET_BETRAY_REWARD = "event@getBetrayReward";

        public const string FACTION_CHANGE_GET_BETRAY_REGINFO = "event@getBetrayRegInfo";

        public const string FACTION_CHANGE_GET_PLAYER_NAMES = "event@getTenPlayerNamesByForceId";

        public const string FACTION_CHANGE_NO_CHANGENAME = "event@giveUpBetrayChangeName";

        public const string CATAPULT_GET_CATAPULT_INFO = "catapult@getCatapultInfo";

        public const string CATAPULT_BUY_CATAPULT = "catapult@buyCatapult";

        public const string CATAPULT_DONGHUA = "catapult@donghua";

        public const string CATAPULT_UPGRADE = "catapult@upgrade";

        public const string CHARIOT_UPGRADE = "chariot@upgrade";

        public const string CHARIOT_GET_CHARIOTINFO = "chariot@getChariotInfo";

        public const string CHARIOT_BUY_BLUEPRINT = "chariot@buyBlueprint";

        public const string CHARIOT_GET_EQUIPPABLEGENERALS = "chariot@getEquippableGenerals";

        public const string CHARIOT_EQUIP = "chariot@equip";

        public const string CATAPULT_SUPER_UPGRADE = "catapult@superForge";

        public const string NEWCHARIOT_GETINFO = "chariot@getInfo";

        public const string NEWCHARIOT_MAKESP = "chariot@forgeSp";

        public const string NEWCHARIOT_MAKEBP = "chariot@forgeBp";

        public const string NEWCHARIOT_GETGENERAL = "chariot@getGenerals";

        public const string NEWCHARIOT_EQUIP = "chariot@equip";

        public const string NEWCHARIOT_GETBODY = "chariot@getBpInfo";

        public const string NEWCHARIOT_OPENRFT = "chariot@openRft";

        public const string NEWCHARIOT_RFT = "chariot@rft";

        public const string NEWCHARIOT_RFTUPDATE = "chariot@upgradeRft";

        public const string NEWCHARIOT_SUPER_FORGESP = "chariot@superForgeSp";

        public const string NEWCHARIOT_SUPER_RFT = "chariot@superRft";

        public const string NEWCHARIOT_CAREFULL_FORGESP = "chariot@carefulForgeSp";

        public const string NEWCHARIOT_CAREFULL_YTL = "chariot@forgeSpUseYlt";

        public const string NEWCHARIOT_USE_FENG_CHU_LOOP = "chariot@useFengChuLoop";

        public const string NEWCHARIOT_FORGE_SP_QIXING_LAMP = "chariot@forgeSpWithQiXingLamp";

        public const string NEWCHARIOT_RFT_WITH_QIXING_LAMP = "chariot@rftWithQiXingLamp";

        public const string NEWCHARIOT_CITY_SHOW = "chariot@show";

        public const string NEWCHARIOT_ARM = "chariot@arm";

        public const string NEWCHARIOT_GET_ARM_PART_LIST = "chariot@getArmPartList";

        public const string NEWCHARIOT_UPDATE_ARM_PART = "chariot@updateArmPart";

        public const string NEWCHARIOT_RFT_WITH_TICKET = "chariot@rftWithTicket";

        public const string NEWCHARIOT_ELEMENT_DRAW_GET_INFO = "chariot@elementDrawGetInfo";

        public const string NEWCHARIOT_ELEMENT_GET_INFO = "chariot@elementGetInfo";

        public const string NEWCHARIOT_ELEMENT_BUILD = "chariot@elementBuild";

        public const string NEWCHARIOT_ELEMENT_STRENGTHEN = "chariot@elementStrengthen";

        public const string NEWCHARIOT_ELEMENT_RECAST = "chariot@elementRecast";

        public const string KFYZ_SING_UP = "kfyz@signUp";

        public const string KFYZ_LOGIN = "kfyz@kfgzlogin";

        public const string KFYZ_SIMPLE_TASK_INFO = "kfyz@getSTaskInfo";

        public const string KFYZ_TASK_INFO = "kfyz@getTaskInfo";

        public const string KFYZ_TASK_REWARD_INFO = "kfyz@getTaskInfo";

        public const string KFYZ_GET_TASK_REWARD = "kfyz@getTaskRewards";

        public const string KFYZ_GET_NATION_STORE_INFO = "kfyz@getNationMineInfo";

        public const string KFYZ_GET_NATION_STORE_REWARD = "kfyz@getTodayMine";

        public const string KFYZ_GET_NATION_STORE_LIST = "kfyz@queryServerList";

        public const string KFYZ_GET_NATION_STORE_TO_WAR = "kfyz@chooseYzServer";

        public const string KFYZ_GET_NATION_STORE_TO_WAR_MORE = "kfyz@chooseServers";

        public const string KFYZ_GET_NATION_STORE_LOCK = "kfyz@lockNation";

        public const string KFYZ_GET_NATION_STORE_UNLOCK = "kfyz@unLockNation";

        public const string KFYZ_PREPARE = "kfyz@getInvestInfo";

        public const string KFYZ_BUY = "kfyz@investGoods";

        public const string KFYZ_NO_WAR = "kfyz@noDisturb";

        public const string KFYZ_NO_WAR_INFO = "kfyz@getDisturbInfo";

        public const string KFYZ_NO_WAR_GET_REWARD = "kfyz@getDisturbRewards";

        public const string KFYZ_CLICK = "kfyz@notifyOrderYz";

        public const string KFYZ_ATTACK_MORE = "kfyz@getDividedInfo";

        public const string KFYZ_ADD_MORE = "kfyz@roadSign";

        public const string KFYZ_ATTACK_MORE_LIST = "kfyz@getSignInfo";

        public const string KFYZ_REBUILD = "kfyz@rebuilt";

        public const string KFYZ_INDIV_TASK_SIMPLE_INFO = "kfyz@getSIndivTasks";

        public const string KFYZ_INDIV_TASK_INFO = "kfyz@getIndivTasksInfo";

        public const string KFYZ_INDIV_TASK_REWARD = "kfyz@getIndivTasksRewards";

        public const string KFYZ_STORE = "kfyz@getArmyBaseInfo";

        public const string KFYZ_STORE_USE = "kfyz@useArmyBaseInfo";

        public const string KFYZ_STORE_LIST_REFRESH_ONE = "kfyz@refreshAServer";

        public const string KF_PUSH_START = "kf@enter";

        public const string KF_PUSH_STOP = "kf@leave";

        public const string KFYZ_ROME_PREPARE = "kfyzRome@prepare";

        public const string KFYZ_ROME_BATTLE_START = "kfyzRome@battleStart";

        public const string KFYZ_GET_FB_TUJIN = "kfworld@getFBTujinResult";

        public const string OPEN_LIGHT_INFO = "light@getLightInfo";

        public const string OPEN_LIGHT_BUY_POINT = "light@buyPoint";

        public const string OPEN_LIGHT_EXECUTE = "light@openLight";

        public const string OPEN_LIGHT_FINAL_UPGRADE = "light@sublimate";

        public const string GET_CRAFTSMAN_INFO = "bestSuit@getTabInfo";

        public const string CRAFTSMAN_INJECTRESOURCE = "bestSuit@injectResource";

        public const string CRAFTSMAN_SUIT_UPGRADE = "bestSuit@upgrade";

        public const string CRAFTSMAN_RECV_STONE = "bestSuit@recvStone";

        public const string GET_USER_SETTING = "player@getUserSetting";

        public const string SET_USER_SETTING = "player@setUserSetting";

        public const string OVER_CARD_BEGIN_CHOOSE = "event@chooseTurn";

        public const string OVER_CARD_CHOOSE = "event@chooseCard";

        public const string OVER_CARD_CHOOSE_ALL = "event@openAllCards";

        public const string OVER_CARD_BUY_COUNT = "event@goldBuyTimes";

        public const string OVER_CARD_GET_NEW_CARDS = "event@getShowCards";

        public const string OVER_CARD_GET_GIFT = "event@receivedCardTickets";

        public const string NEW_GEM_OPEN_GEM = "event@startKnockNewGems";

        public const string NEW_GEM_GET_REWARD = "event@knockNewGems";

        public const string NEW_GEM_GET_REWARD_PIECE = "event@getReward";

        public const string NEW_GEM_GIVE_UP_GEM = "event@giveUpGemStone";

        public const string NEW_GEM_GOLD_BUY = "event@buyKnockNewGemsTimes";

        public const string METEORITE_GIVE_UP = "meteorite@giveUp";

        public const string METEORITE_START_HIT = "meteorite@startHit";

        public const string METEORITE_GET_REWARD = "event@getReward";

        public const string METEORITE_HIT = "meteorite@hit";

        public const string GOD_POT_GET_GEM_LIST = "event@getGemList";

        public const string LOAD_GEM_TO_FURNACE = "event@loadGemToFurnace";

        public const string UNLOAD_GEM_TO_FURNACE = "event@unLoadGemFromFurnace";

        public const string INVEST_WOOD_TO_FURNACE = "event@investWoodToFurnace";

        public const string NEW_TURN_ROTARY = "event@turnRotary";

        public const string NEW_BUY_TURN_ROTARY_TIMES = "event@buyTurnRotaryTimes";

        public const string NEW_BUY_TURN_ROTARY_LEVEL = "event@markUpRateRotary";

        public const string NEW_BUY_TURN_ROTARY_GET_REWARD = "event@getReward";

        public const string KONG_MING_SAY = "event@praiseLantern";

        public const string KONG_MING_FLY = "event@flySkyLantern";

        public const string KONG_MING_GET = "event@getSelfReward";

        public const string KONG_MING_OTHER_GET = "event@getOthersReward";

        public const string BATTLE_USE_FLAG = "battle@useFlag";

        public const string MAGAINE_DETONATE = "magazine@detonate";

        public const string BATTLE_SLAUGHTER = "battle@slaughter";

        public const string GAME_SERVER_USE_TOOL = "gameserver@useTool";

        public const string SLAUGHT_SLAUGHT = "battle@slaughter";

        public const string WORLD_ROB = "battle@rob";

        public const string OFFLINE_GETINFO = "offline@getInfo";

        public const string GET_GEM_FOR_USE = "equip@getEquipForUseRefineItem";

        public const string GET_GEM_CHANGE_SKILL = "equip@useJinLianToken";

        public const string ACTIVITY_GET602VIPREWARDINFO = "activity@get602VipRewardInfo";

        public const string ACTIVITY_RECV602VIPREWARD = "activity@recv602VipReward";

        public const string SILK_GET_SILK_INFO = "silk@getSilkInfo";

        public const string SILK_GET_EVENT_INFO = "silk@getEventInfo";

        public const string SILK_HANDLE_EVENT = "silk@handleEvent";

        public const string SILK_DISPATCH = "silk@dispatch";

        public const string SILK_GET_REWARD_LIST = "silk@getRewardList";

        public const string SILK_SILK_BUSINESS = "silk@useMerchantToken";

        public const string SILK_PICK_TRADEPIECE = "silk@pickTradePiece";

        public const string SILK_USE_CAMELBELL = "silk@useCamelBell";

        public const string SILK_GET_COMPASSPIECEL = "silk@getCompassPiece";

        public const string SILK_GET_MEDALRANK = "silk@getSilkMedalRankList";

        public const string SILK_GOTODREAMNATION = "silk@goToDreamNation";

        public const string SILK_GOTOTZNATION = "silk@goToTZNation";

        public const string SILK_GET_ASSISTINFO = "silk@getAssistInfo";

        public const string SILK_GET_GIFT = "silk@getGift";

        public const string SILK_ASSSIST = "silk@asssist";

        public const string SILK_GET_TREASURE_IFNO = "silk@getTreasureInfo";

        public const string SILK_GET_DIDI_INFO = "silk@getDidiInfo";

        public const string SILK_SEARCH = "silk@startDidi";

        public const string SILK_GET_ON = "silk@getOnDidi";

        public const string SILK_GET_OFF = "silk@getOffDidi";

        public const string SILK_CANCEL_DIDI = "silk@cancelDidi";

        public const string SILK_GET_DIDI_REWARD = "silk@getDidiReward";

        public const string SILK_GET_DIDI_DRIVERS = "silk@getDidiDrivers";

        public const string BUILDING_WOOD_CHANGE = "building@changeBuilding";

        public const string BUILDING_LEIZU_CHANGE = "building@lumberYardReform";

        public const string BUILDING_LEIZU_LEVEL = "building@reformPrepare";

        public const string BUILDING_LEIZU_REWARD = "building@receiveReformRewards";

        public const string BUILDING_FARM_CHANGE = "building@farmReform";

        public const string BUILDING_FARM_REWARD = "building@receiveFRRewards";

        public const string BUILDING_FARM_LEVEL = "building@reformFarmPrepare";

        public const string BUILDING_ZHOUGONG_CHANGE = "building@lumberYardReformPlus";

        public const string BUILDING_ZHOUGONG_LEVEL = "building@reformPlusPrepare";

        public const string NEW_FARM_REFORM = "folkHouse@reform";

        public const string FETEHERO_REWARD = "entertainLord@getQyhRewards";

        public const string SILK_MARKET_INFO = "market@getSilkMarketInfo";

        public const string SILK_MARKET_GOODS_DETAIL_INFO = "market@getSilkMarketDetailInfo";

        public const string SILK_MARKET_BUY = "market@buySilk";

        public const string SILK_MARKET_SELL = "market@sellSilk";

        public const string SILK_MARKET_CANCEL = "market@redeemSilk";

        public const string SILK_MARKET_REWARD = "market@recvSilkGold";

        public const string SLAUGHT_INTERACTION_INFO = "battle@celSlaughterPanel";

        public const string SLAUGHT_INTERACTION_REWARD = "battle@celSlaughter";

        public const string SLAUGHT_INTERACTION_START_SWEEPING = "battle@startClean";

        public const string SLAUGHT_INTERACTION_CONFIRM = "battle@confirmNotify";

        public const string SLAUGHT_ROB_REWARD = "battle@robReward4Weapon";

        public const string COOP_SLAUGHER_PANEL = "battle@coopSlaughterPanel";

        public const string GET_COOP_SLAUGHER_REWARD = "battle@getCoopSlaughterReward";

        public const string GET_CITY_SLAUGHTERS = "battle@getCitySlaughters";

        public const string ACTIVITY_GET_SHEEP_REWARD = "activity@getSheepRewards";

        public const string ACTIVITY_BUY_SHEEP = "activity@buySheep";

        public const string REWARD_GENERAL_BUY_MATERIAL = "event@buyFood";

        public const string REWARD_GENERAL_RESET = "event@resetCurLoop";

        public const string REWARD_GENERAL_BIG_REWARD = "event@getBigReward";

        public const string REWARD_GENERAL_BOX_REWARD = "event@openRewardGeneralBox";

        public const string ACTIVITY_FISHING_START = "event@startFish";

        public const string ACTIVITY_FISHING_NET = "event@useNet";

        public const string ACTIVITY_FISHING_BOX = "event@exchangeReward";

        public const string ACTIVITY_FISHING_CHANGE_BOX = "event@exchangeReward";

        public const string ACTIVITY_FISHING_OPEN_BOX = "event@openFishBox";

        public const string ACTIVITY_FISHING_BIG_REWARD = "event@getReward";

        public const string SILK_PRESSICON = "silk@pressIcon";

        public const string ACTIVITY_SUPER_TURN_BUY = "event@buySuperTurnRotaryTimes";

        public const string ACTIVITY_SUPER_TURN_BEGIN = "event@turnSuperRotary";

        public const string ACTIVITY_SUPER_TURN_REWARD = "event@getReward";

        public const string ACTIVITY_SUPER_TURN_LEVELUP = "event@markUpSuperRateRotary";

        public const string BUILD_REFORM_BUILDING = "building@reformBuilding";

        public const string BUILD_REFORM_AREA = "building@reformArea";

        public const string BUILDING_FOOD_HARVEST = "building@foodHarvest";

        public const string SLAVE_BUY_GRAB = "slave@buyGrab";

        public const string QING_MING_UPGRADE_PIG = "event@upgradePig";

        public const string QING_MING_EAT_PIG = "event@feedPig";

        public const string GOTO_INCENSE = "event@goWorship";

        public const string COOKING_BUY_DRINK = "event@buyDrink";

        public const string COOKING_UPGRATE_DRINK = "event@upgrateDrink";

        public const string COOKING_JUNKET = "event@junket";

        public const string COOKING_BANQUET = "event@banquet";

        public const string COOKING_DRINK_TOGETHER = "event@drinkTogether";

        public const string COOKING_FAREWELL = "event@farewell";

        public const string COOKING_DRINK_ALONE = "event@drinkAlone";

        public const string COOKING_SET_AUTO_DRINK = "event@setAutoDrink";

        public const string DRINK_EVOKE_WITH_GOLD = "evoke@drinkEvokeWithGold";

        public const string DRINK_EVOKE_WITH_GEM = "evoke@drinkEvokeWithGem";

        public const string DRINK_EVOKE_WITH_STONE = "evoke@drinkEvokeWithStone";

        public const string DRINK_EVOKE_WITH_2302 = "evoke@drinkEvokeWith2302";

        public const string DRINK_EVOKE_WITH_DUKANG = "evoke@evokeWithDukang";

        public const string DRINK_EVOKE_WITH_ZHUGEWINE = "evoke@evokeWithZhugeWine";

        public const string DRINK_EVOKE_WITH_JRCN = "evoke@evokeWithBeautyWine";

        public const string DRINK_EVOKE_WITH_DCCN = "evoke@evokeWithTreasureWine";

        public const string GET_DEPOSIT_INFO = "player@getHostedInfo";

        public const string DEPOSIT_PLAYER = "player@queryHost";

        public const string SEARCH_PLAYER = "player@queryCanHost";

        public const string ACCPET_DEPOSIT = "player@dealHostQuery";

        public const string CANCEL_DEPOSIT = "player@cancelHost";

        public const string UPGRADE_HORSE = "event@upgradeHorse";

        public const string BUY_HORSE_RACING_TIME = "event@buyHorseRacingTime";

        public const string START_HORSE_RACING = "event@startHorseRacing";

        public const string SET_HORSE_POSITON = "event@setHorsePositon";

        public const string GET_READY = "event@getReady";

        public const string HORSE_RACING_BUY_WIN = "event@directHorseRacing";

        public const string HORSE_RACING_KILL_CD = "event@horseRacingCd";

        public const string EVOKE_SILK_GIFT_REWARD = "evoke@getEvokeSilkGift";

        public const string GRAB_GET_BAG = "event@sendRedBag";

        public const string GRAB_GET_BAG_MORE = "event@recvOwnRedBag";

        public const string GET_GRAB_PANEL_INFO = "event@getRedBagInfo";

        public const string GET_MY_GRAB_PANEL_INFO = "event@getOwnRedBagInfo";

        public const string GET_GRAB_PANEL_REWARD = "event@recvRedBag";

        public const string GRAB_GIVE_BAG = "event@deliverRedBag";

        public const string GET_BUILD_FORT_INFO = "castle@getCanBuildInfo";

        public const string BUILD_FORT = "castle@buildCastle";

        public const string ADD_BUILD_FORT = "castle@startBuild";

        public const string GET_BUILD_FORT_REWARD = "castle@getReward";

        public const string BUILD_FORT_MOVE = "castle@autoMove";

        public const string BUILD_TASK_INFO = "kbtask@getSTaskInfo";

        public const string CHANGE_NATION = "kbtask@setForceName";

        public const string SIGN_COMPLETE = "kbtask@getSignInfo";

        public const string SIGN_MY = "kbtask@sign";

        public const string JAPAN_SIGN_COMPLETE = "kbtask@getJpsSignInfo";

        public const string ADD_BUILD_LIST = "castle@getBuildWorkers";

        public const string ASK_BUILD_FORT = "castle@call";

        public const string ADVICE_BUILD_FORT = "castle@advice";

        public const string CLICK_CASTLE_ICON = "castle@iconNotify";

        public const string POWER_ENTER_CBHS_POWER = "power@enterCbhsPower";

        public const string POWER_FINISH_CBHS_POWER = "power@finishCbhsPower";

        public const string CLICK_LOOK_BUTTON = "event@clickLookButton";

        public const string THROW_DICE = "event@throwDice";

        public const string LOOK_WALK = "event@lookWalk";

        public const string FAREWELL = "event@farewell";

        public const string LOOK_SMALL_BOX = "event@lookSmallBox";

        public const string GET_GEM_BONUS_INFO = "power@getGemBonusInfo";

        public const string TOURISM_SELECT_GENERAL = "event@selectGeneral";

        public const string TOURISM_NEXT_SCENIC = "event@nextScenic";

        public const string TOURISM_HANDLE_SCENIC_EVENT = "event@handleScenicEvent";

        public const string TOURISM_END_SCENIC = "event@endScenic";

        public const string GEM_MINE_BUY_BOMB = "event@buyGemMineBomb";

        public const string GEM_MINE_BOMB = "event@bombGemMine";

        public const string GEM_MINE_REWARD = "event@receivedBombGem";

        public const string GEM_MINE_BOMB_ALL = "event@bombAllGemMineWithReward";

        public const string GEM_MINE_NEXT = "event@gemMineNextRound";

        public const string GET_WARLEGION_WORLD_INFO = "team@getTeamSendCity";

        public const string CHOOSE_RESOURE_TYPE = "feud@trigger";

        public const string BEGIN_PRODUCE_TYPE = "feud@start";

        public const string GET_PRODUCE_REWARD = "feud@getReward";

        public const string KILL_PRODUCE_CD = "feud@fastRecoverCd";

        public const string FAST_RESOURE = "feud@fastWithWorker";

        public const string GET_CITY_FEUD = "feud@getCityFeudInfo";

        public const string TOKEN_OVER_FLOW = "feud@check";

        public const string BATTLE_GETCHAINABLECITIES = "battle@getChainableCities";

        public const string KF_BATTLE_GETCHAINABLECITIES = "kfBattle@getChainableCities";

        public const string BATTLE_CHAINCITIES = "battle@chainCities";

        public const string KF_BATTLE_CHAINCITIES = "kfBattle@chainCities";

        public const string ACTIVITY_MOONCAKE_BUYTIME = "event@buyNewRound";

        public const string ACTIVITY_MOONCAKE_STARTEAT = "event@startEatMoonCake";

        public const string ACTIVITY_MOONCAKE_OVERONEBOWL = "event@overOneBowl";

        public const string ACTIVITY_MOONCAKE_GETREWARD = "event@getReward";

        public const string ACTIVITY_VISITORGIFT_SENDINVITATION = "event@sendInvitation";

        public const string ACTIVITY_VISITORGIFT_GETREWARD = "event@getVisitorGift";

        public const string ACTIVITY_VISITORGIFT_CHOOSEREWARDTYPE = "event@chooseRewardType";

        public const string FARM_BUY_FARM_TOKEN = "farm@buyFarmToken";

        public const string GET_BUILDEVENT_REWARDINFO = "world@getBuildRewardInfo";

        public const string RECEIVE_BUILDEVENT_REWARD = "world@recvBuildReward";

        public const string KF_DEAL_JPS_EVENT = "gameserver@dealJpsEvent";

        public const string KF_GET_KILL_GENERAL_INFOS = "gameserver@getKillGeneralInfos";

        public const string BUY_CARD_REWARD = "event@pickCard";

        public const string USE_SILK_CARD_TOKEN = "event@useSilkCardToken";

        public const string NOTICE_100_INFO = "notice@getNoticeInfo";

        public const string NOTICE_100_REWARD = "notice@getNoticeReward";

        public const string CIVIL_CLICKPROMOTION = "civil@clickPromotion";

        public const string SEA_SILK_ROAD_GET_INFO = "seaSilkRoad@getInfo";

        public const string SEA_SILK_ROAD_EMPOLY = "seaSilkRoad@employ";

        public const string SEA_SILK_ROAD_GET_WINDOWS_INFO = "seaSilkRoad@getWindowsInfo";

        public const string SEA_SILK_ROAD_BUY_WINDOWS = "seaSilkRoad@buyWindows";

        public const string SEA_SILK_ROAD_GET_REWARD = "seaSilkRoad@getReward";

        public const string GENERAL_GO_HOME = "general@goHome";

        public const string BATTLE_LIT_FIRE = "battle@litFire";

        public const string BATTLE_EXTING_GUISH = "battle@extinguish";

        public const string ANNI_BAN_INFO = "celebration@getCelebrationInfo";

        public const string ANNI_BAN_ROOM_INFO = "celebration@getRoomInfo";

        public const string ANNI_BAN_SEND_GIFT_BOX = "celebration@giveBox";

        public const string ANNI_BAN_OPEN_PRIVATE = "celebration@openParty";

        public const string ANNI_BAN_ATTEND_PRIVATE = "celebration@attendParty";

        public const string ANNI_BAN_ATTEND_MYTH = "celebration@giveBoxForNpc";

        public const string ANNI_BAN_BUY_MYTH = "celebration@costGoldForNpc";

        public const string ANNI_BAN_RANK_INFO = "celebration@getRankInfo";

        public const string ISLAND_LVUP_SAILOR = "event@lvUpSailor";

        public const string ISLAND_BUY_DOUBLE = "event@buySeasilkDouble";

        public const string ISLAND_MAX_LV_SAILOR = "event@maxLvSailor";

        public const string ISLAND_REFRESH_SAILOR = "event@refreshSailor";

        public const string SILK_CLICK_SIX_TREASURE_ICON = "silk@clickSixTreasureIcon";

        public const string SILK_CLICK_SEVEN_TREASURE_ICON = "silk@clickSevenTreasureIcon";

        public const string CORPS_WITH_DRAW = "corps@withdraw";

        public const string CORPS_DASH = "corps@dash";

        public const string CORPS_SOLO = "corps@solo";

        public const string CORPS_CHECK_DASH_AND_WITH_DRAW = "corps@checkDashAndWithdraw";

        public const string CORPS_CREATE = "corps@createCorps";

        public const string CORPS_ADDPHANTOM = "corps@addPhantom";

        public const string CORPS_GET_INFO = "corps@getCorpsInfo";

        public const string CORPS_GET_CANDIDATE = "corps@getCandidate";

        public const string CORPS_TRANSFER = "corps@transferCorps";

        public const string CORPS_CANCEL_TRANSFER = "corps@cancelTransferCorps";

        public const string CORPS_AGREE_TRANSFER = "corps@agreeTransferCorps";

        public const string CORPS_GO = "corps@corpsGo";

        public const string CORPS_DISBLAND = "corps@dismissCorps";

        public const string CORPS_MOVE = "corps@move";

        public const string COPS_STOP = "corps@stop";

        public const string COPS_GETPHANTOMLIST = "corps@getPhantomList";

        public const string COPS_KICKPHANTOM = "corps@kickPhantom";

        public const string FORCETASK_RECEIVE = "forceTask@receiveTask";

        public const string FORCETASK_CANCEL = "forceTask@cancelTask";

        public const string FORCETASK_FINISH = "forceTask@finishTask";

        public const string FORCETASK_FAST_TASK = "forceTask@fastTask";

        public const string GET_SWEEPREWARD = "battle@getSweepReward";

        public const string QINGMING_2016_DRINK_TEA = "tsd@startNewRound";

        public const string QINGMING_2016_DRINK_WINE = "tsd@drink";

        public const string QINGMING_2017_DRINK = "qingmei@drink";

        public const string QINGMING_2017_NEXT = "qingmei@nextRound";

        public const string QINGMING_2017_NEXT_HERO = "qingmei@nextGeneral";

        public const string ARENA_GET_CANDIDATE = "arena@getCandidate";

        public const string ARENA_CHOOSE_CHAMPION = "arena@chooseChampion";

        public const string ARENA_CHALLENGE = "arena@challenge";

        public const string ARENA_ACTIVATE_ARENA = "arena@activateArena";

        public const string ARENA_TAUNT = "arena@taunt";

        public const string KF_ARENA_GET_CANDIDATE = "kfArena@getCandidate";

        public const string KF_ARENA_CHOOSE_CHAMPION = "kfArena@chooseChampion";

        public const string KF_ARENA_CHALLENGE = "kfArena@challenge";

        public const string KF_ARENA_ACTIVATE_ARENA = "kfArena@activateArena";

        public const string KF_ARENA_START_BATTLE = "kfArena@startBattle";

        public const string KF_ARENA_TAUNT = "kfArena@taunt";

        public const string KF_DETONATE = "kfBattle@detonate";

        public const string KF_LIT_FIRE = "kfBattle@litFire";

        public const string KF_EXTINGUISH = "kfBattle@extinguish";

        public const string BATTLE_CHAGE_MODE = "battle@changeMode";

        public const string GET_CASTING_FIRE_IFNO = "kfyz@smeltMedalList";

        public const string CASTING_MEDAL = "kfyz@smeltMedal";

        public const string GET_CASTING_IFNO = "ycbw@getPanelInfo";

        public const string GET_DRAWING_IFNO = "ycbw@getDrawingInfo";

        public const string CHOOSE_DRAWING = "ycbw@chooseDrawing";

        public const string START_MAKE = "ycbw@startMake";

        public const string CHOOSE_WARN = "ycbw@canelWarn";

        public const string CHANGE_DRAWING = "ycbw@chooseQuality";

        public const string GET_PRIMER_INFO = "ycbw@getPrimerInfo";

        public const string CHANGE_CASTING_MODE = "ycbw@changeMode";

        public const string GET_CASTING_MADE_LIST = "ycbw@getSpecList";

        public const string GET_CASTING_QUENCH = "ycbw@quench";

        public const string CHOOSE_QUENCH = "ycbw@chooseFeature";

        public const string CASTING_EVOLUTION = "ycbw@evolution";

        public const string CASTING_RESOLVE = "ycbw@resolve";

        public const string BUY_MATERIAL = "ycbw@buyMaterial";

        public const string BUY_COAL = "ycbw@buyCoal";

        public const string FAST_MAKE = "ycbw@reduceCd";

        public const string FINISH_MAKE = "ycbw@finishMake";

        public const string BUY_OUT_PUT = "ycbw@buyOutput";

        public const string BUY_PROB = "ycbw@buyProb";

        public const string FILL_PRIMER = "ycbw@fillPrimer";

        public const string QUICK_RECVEXMATERIAL = "ycbw@recvExMaterial";

        public const string QUICK_CHANGE = "ycbw@changeSideBar";

        public const string GET_WEARABLE_YCBW = "ycbw@getWearableYcbw";

        public const string WEAR_YCBW = "ycbw@wearYcbw";

        public const string TAKE_OFF_YCBW = "ycbw@takeoffYcbw";

        public const string ZONGZI_GIVING_GIVE = "dwxz@giveAway";

        public const string ZONGZI_GIVING_NEXT = "dwxz@enterNext";

        public const string ZONGZI_GIVING_START = "dwxz@startNewRound";

        public const string ZONGZI_GIVING_FAIRY = "dwxz@playWithFairy";

        public const string WORLD_TRIGGER_CONQUER = "world@triggerConquer";

        public const string WORLD_END_CONQUER = "world@endConquer";

        public const string NEW_SERVER_BACK_GET_REWARD = "event@getReward";

        public const string CHRISTMAS_DISPATCH = "christmas@dispatch";

        public const string CHRISTMAS_GET_EVENT_INFO = "christmas@getEventInfo";

        public const string CHRISTMAS_HANDLE_EVENT = "christmas@handleEvent";

        public const string CHRISTMAS_GET_REWARD_LIST = "christmas@getRewardList";

        public const string CONQUER_BUY_TIME = "conquer@buyTime";

        public const string CONQUER_START = "conquer@startConquer";

        public const string CONQUER_BUY_NUM = "conquer@buyNum";

        public const string COLOSS_EUM_ACTVIVIL = "colosseum@actCivil";

        public const string COLOSS_EUM_SAVE_GIDS = "colosseum@saveGids";

        public const string ACTIVITY_GETFETEHEROREWARD = "entertainLord@getSpecialRewards";

        public const string ACTIVITY_BUYCOMBO = "entertainLord@buyCombo";

        public const string ACTIVITY_GETLVREWARD = "entertainLord@getBuffReward";

        public const string CHARIOT_SCOUT_METEOR = "chariot@scoutMeteor";

        public const string ACTIVITY_SELECT_RIVER = "arrowBoat@shootMe";

        public const string ACTIVITY_BOATARROW_INFO = "event@getInfo";

        public const string ACTIVITY_DISPATCH = "arrowBoat@dispatch";

        public const string ACTIVITY_BOAT_RESTART = "arrowBoat@restart";

        public const string ACTIVITY_BOATARROW_GETREWARD = "event@getReward";

        public const string ACTIVITY_BOAT_GETLVREWARD = "arrowBoat@getSpReward";

        public const string ACTIVITY_CBTW_ZHANFA = "changban@win";

        public const string ACTIVITY_CBTW_BUYHP = "changban@buyHp";

        public const string ACTIVITY_SM_GETSP = "yb17@getSpRewInfo";

        public const string ACTIVITY_SM_RANK = "yb17@getDmgCharts";

        public const string ACTIVITY_SPREWARD_RANK = "yb17@getRwdCharts";

        public const string EQUIP_GET_MEDALS = "equip@getMedals";

        public const string EQUIP_USE_MEDAL = "equip@useMedal";

        public const string EQUIP_UNLOAD_MEDAL = "equip@unloadMedal";

        public const string KFYZ_GET_MEDAL = "kfyz@getMedal";

        public const string WORLD_FIREWORK_REWARDS = "world@fireworkRewards";

        public const string MAINCITY_MOHIST_REFORM = "mohist@reform";

        public const string MAINCITY_MOHIST_COMPLETE = "mohist@complete";

        public const string MAINCITY_MOHIST_DAILY_REWARD = "mohist@recvDailyReward";

        public const string MAINCITY_MOHIST_REFORM_REWARD = "mohist@recvStarReward";

        public const string NEW_FESTIVAL_RANK = "event@getNewLanternRankInfo";

        public const string ATTACKTANK_GETREWARD = "tankCharge@getFreeTimes";

        public const string XIANG_YANG_SEARCH = "xiangyang@search";

        public const string XIANG_YANG_ADD_HELPER = "xiangyang@addHelper";

        public const string XIANG_YANG_OPEN_GATE = "xiangyang@openGate";

        public const string XIANG_YANG_NEXT_GROUP = "xiangyang@nextGroup";

        public const string XIANG_YANG_RESET_SEARCH = "xiangyang@resetSearch";

        public const string XIANG_YANG_REWARD_INFO = "xiangyang@rewardInfo";

        public const string XIANG_YANG_REWARD = "xiangyang@reward";

        public const string CHARIOT_EXCHANGE = "chariot@exchange";

        public const string BILIBILI_QUIT = "kfzb@closeBattle";

        public const string BROKEN_WORLD_GETINFO = "brokenWorld@getInfo";

        public const string BROKEN_WORLD_GET_REWARD = "brokenWorld@getReward";

        public const string BROKEN_WORLD_GET_OCCUPY_REWARD = "brokenWorld@getOccupyReward";

        public const string FLOURISH_GET_NEW_FUNCTION = "flourish@getNewFunction";

        public const string GET_TRIALGENERAL_INFO = "battle@getTrialGeneralInfo";

        public const string SUPPORT_GET_INFO = "support@getInfo";

        public const string SUPPORT_REQUEST = "support@request";

        public const string SUPPORT_GET_CANDIDATE = "corps@getCandidate";

        public const string SUPPORT_SUPPORT = "support@support";

        public const string SUPPORT_RESPONSE = "support@response";

        public const string SUPPORT_TRANSFER_CORPS = "corps@transferCorps";

        public const string SUPPORT_GET_REWARD = "support@getBoxReward";

        public const string METEO_MARKET_REFRESH = "meteomarket@refresh";

        public const string METEO_MARKET_BUY = "meteomarket@buy";

        public const string METEO_MARKET_ALL_BUY = "meteomarket@allBuy";

        public const string ZHEN_BAO_SPRINT_BUY = "treasuremarket@buy";

        public const string ZHEN_BAO_SPRINT_ALL_BUY = "treasuremarket@allBuy";

        public const string GET_MILITARY_INFO = "military@getMilitaryInfo";

        public const string GET_MILITARY_REWARD = "military@getReward";

        public const string ZHUGE_STAR_BUILD = "zhugeWatchStar@build";

        public const string ZHUGE_STAR_SPECIAL_REWARD = "zhugeWatchStar@getSpecialReward";

        public const string ZHUGE_STAR_CHANGE_STAR = "zhugeWatchStar@changeStar";

        public const string ZHUGE_STAR_WATCH_STAR = "zhugeWatchStar@watchStar";

        public const string RANK_GET_TAG_REWARD = "rank@getTagReward";

        public const string CAMP_GET_INFO = "machineCamp@getInfo";

        public const string CAMP_UP_LV = "machineCamp@upLv";

        public const string CAMP_GET_REWARD = "machineCamp@getReward";

        public const string CAMP_WANTED_MAN_REWARD = "machineCamp@wantedmanReward";

        public const string CAMP_WORKING = "machineCamp@working";

        public const string GET_WANTED_PLAYER_TASK_INFO = "world@getWantedPlayerTaskInfo";

        public const string GET_WANTED_PLAYER_LOCATION = "world@getWantedPlayerLocation";

        public const string TAVERN_GET_AVOKE_GENERALS = "evoke@getEvokeHall";

        public const string TAVERN_GET_FETTER_GENERALS = "evoke@getGeneralFetters";

        public const string PARADE_DO_COPYARMY = "parade@doCopyArmy";

        public const string GET_NATIONALDAY_MONSTERRANK = "paradeEvent@getCharts";

        public const string PARADE_GET_FEASTINFO = "parade@getFeastInfo";

        public const string PARADE_GET_REWARD = "event@getReward";

        public const string PARADE_EXCHANGE_MILITARY_FEAT = "parade@exchangeMilitaryFeat";

        public const string PARADE_GET_FEAT = "paradeEvent@getFeat";

        public const string PARADE_GET_HZSKIN = "parade@getHzSkin";

        public const string GET_TACTICAL_INFO = "strategics@basic";

        public const string GET_TACTICAL_LEARN_INFO = "strategics@detail";

        public const string GET_WEAR_TACTICAL = "strategics@getWearStrategics";

        public const string CHANGE_WEAR_TACTICAL = "strategics@changeStrategics";

        public const string UNLOCK_POSITION_TACTICAL = "strategics@unlockPosition";

        public const string GET_TACTICAL_GENERAL = "strategics@getWearGeneral";

        public const string CHANGE_WEAR_GENERAL = "strategics@changeFormation";

        public const string UNLOCK_FORMATION = "strategics@unlockFormation";

        public const string UNLOAD_ALL_STRATEGICS = "strategics@unloadAllStrategics";

        public const string GET_ON_SALE_GIFT_INFO = "onsale@getGoodsInfo";

        public const string BUY_ON_SALE_GIFT_INFO = "onsale@buyGoods";

        public const string GET_ON_SALE_GIFT_BUFF = "event@getReward";

        public const string USE_ON_SALE_GIFT_DISCOUNT = "onsale@useDiscount";

        public const string USE_TREASURE_BOWL = "equip@useTreasureBowl";

        public const string GET_ON_SALE_BIG_REWARD = "onsale@getOnsaleBigReward";

        public const string OGDISPATCH_CHANGE = "ogDispatch@reform";

        public const string OGDISPATCH_GENERAL = "ogDispatch@getDispatchInfo";

        public const string OGDISPATCH_REWARD = "ogDispatch@reward";

        public const string OGDISPATCH_CHANGE_GENERAL = "ogDispatch@chooseGeneral";

        public const string OGDISPATCH_BACK_GENERAL = "ogDispatch@callbackGeneral";

        public const string OGDISPATCH_AFFAIR = "ogDispatch@specialAffairInfo";

        public const string OGDISPATCH_HANDLE_AFFAIR = "ogDispatch@handleSpecialAffair";

        public const string GGZJ_DRINK = "ggzj@drink";

        public const string GGZJ_FIGHT = "ggzj@fight";

        public const string GGZJ_BUY_HP = "ggzj@buyHp";

        public const string STRIKE_BELL_EVENT = "bellEvent@strike";

        public const string STRIKE_BELL_TEMPLE_INFO = "bellEvent@getTempleInfo";

        public const string STRIKE_BELL_GET_REWARD_INFO = "bellEvent@getRewardInfo";

        public const string STRATEGICS_MERGE_GET_INFO = "strategics@mergeGetInfo";

        public const string STRATEGICS_MERGE_GET_STRATEGICS = "strategics@mergeGetStrategics";

        public const string STRATEGICS_MERGE_PUT = "strategics@mergePut";

        public const string STRATEGICS_ONE_KEY_OPERATE = "strategics@oneKeyOperate";

        public const string STRATEGICS_MERGE = "strategics@merge";

        public const string STRATEGICS_MERGE_USE_BUFF = "strategics@mergeUseBuff";

        public const string STRATEGICS_MERGE_USE_XWPW = "strategics@mergeUseXWPW";

        public const string STRATEGICS_MERGE_RECEIVE = "strategics@mergeReceive";

        public const string STRATEGICS_MERGE_ALL = "strategics@mergeAll";

        public const string STRATEGICS_GET_LTCJ = "strategics@getLtcj";

        public const string STRATEGICS_BUY_LTCJ = "strategics@buyLtcj";

        public const string STRATEGICS_LTCJ_MERGE_GETINFO = "strategics@LtcjMergeGetInfo";

        public const string STRATEGICS_LTCJ_MERGE = "strategics@LtcjMerge";

        public const string STRATEGICS_GET_LT_STRATEGICS = "strategics@getLtStrategics";

        public const string STRATEGICS_LT_STRATEGICS_DETAILS = "strategics@LtStrategicsDetails";

        public const string STRATEGICS_GET_LIST_FORLT_UPGRADE = "strategics@getListForLTUpgrade";

        public const string STRATEGICS_LT_STRATEGICS_UPGRADE = "strategics@LtStrategicsUpgrade";

        public const string STRATEGICS_LT_STRATEGICS_ONE_KET_PUT = "strategics@LtStrategicsOneKeyPut";

        public const string STRATEGICS_LT_STRATEGICS_MERGE_ALL = "strategics@LtStrategicsMergeAll";

        public const string STRATEGICS_LT_STRATEGICS_LEVELUP = "strategics@LtStrategicsLevelUp";

        public const string GET_NATION_BATTLE = "kbtask@getDpshInfo";

        public const string GET_NATION_BATTLE_SIGN = "kbtask@getJpsSignInfo";

        public const string START_NATION_BATTLE = "kfyz@subscribeNpcYz";

        public const string WATER_MIRROR_GET_INFO = "waterMirror@getInfo";

        public const string WATER_MIRROR_DRAW = "waterMirror@drawStrategics";

        public const string ZDHL_START = "zdhl@start";

        public const string ZDHL_USE_BUFF = "zdhl@useBuff";

        public const string ZDHL_GET_RANK = "zdhl@getRankInfo";

        public const string ZDHL_GET_REWARD = "event@getReward";

        public const string GET_YUNTIE_BUFF = "equip@getMBasinInfo";

        public const string GET_YUNTIE_BUFF_REWARD = "equip@getMBasinReward";

        public const string ZDHL_GET_CITY_REWARD = "zdhl@getRobInfo";

        public const string ZDHL_BUY_CITY_REWARD = "zdhl@rob";

        public const string ZDHL_REFRESH_CITY_REWARD = "zdhl@robRefresh";

        public const string USE_YT_BOWL = "equip@useMBasin";

        public const string GET_TRIPOD_INFO = "tbTask@getTripodBattleInfo";

        public const string INVEST_TRIPOD_GOODS = "tbTask@investGoods";

        public const string START_BUILD_TRIPOD_ = "tbTask@startBuildTripod";

        public const string LEVEL_TRIPOD = "tbTask@finishTripodDynasty";

        public const string FIRE_WORK_TNT_FIRE = "fireworkTnt@fire";

        public const string FIRE_WORK_TNT_RECEIVE = "fireworkTnt@receiveTnt";

        public const string NEW_YEAR_2018_GET_REWARD = "nyArrival@getCharacterReward";

        public const string NEW_YEAR_2018_GET_BAG = "nyArrival@getYearReward";

        public const string NEW_YEAR_2018_OPEN_BAG = "nyArrival@getArriveReward";

        public const string NEW_YEAR_2018_REFRESH = "nyArrival@refreshPower";

        public const string NEW_YEAR_2018_BIGREWARD = "nyArrival@getBigReward";

        public const string SALE_SOUP_BALL_BUY = "saleSoupBall@buy";

        public const string SALE_SOUP_BALL_REFRESH = "saleSoupBall@refresh";

        public const string SALE_SOUP_BALL_CHOOSE = "saleSoupBall@chooseResouce";

        public const string SALE_SOUP_BALL_RECOVER = "saleSoupBall@recoverCd";

        public const string SALE_SOUP_BALL_RECOVER_CONFIRM = "saleSoupBall@recoverCdConfirm";

        public const string ANCESTOR_GET_INFO = "ancestor@getInfo";

        public const string ANCESTOR_GET_REWARD = "ancestor@getAncestorReward";

        public const string ANCESTOR_BUY_TIMES = "ancestor@buyTimes";

        public const string NATION_TASK_SUPPORT_LB_MILITARY = "nationTask@supportLbMilitary";

        public const string FETE_ANCESTRY_DRAW_STRATEGICS = "feteAncestry@drawStrategics";

        public const string EQUIP_USE_SZBF = "equip@useSzbf";

        public const string EQUIP_USE_JXSP = "equip@useJxsp";

        public const string EQUIP_UPGRADE_STRATEGICS = "strategics@upgradeStrategics";

        public const string UNION_EVOKE_GET_INFO = "unionEvoke@getInfo";

        public const string UNION_EVOKE_OPEN = "unionEvoke@open";

        public const string UNION_EVOKE_WITH_DRINK = "unionEvoke@evokeWithDrink";

        public const string MB_GET_PANEL_INFO = "mb@getPanelInfo";

        public const string MB_BUY = "mb@buy";

        public const string EQUIP_USE_STBAG = "equip@useStBag";

        public const string UNION_EVOKE_RECORD_LIUBEI = "unionEvoke@recordLiuBei";

        public const string YCBW_LOCK = "ycbw@lock";

        public const string YCBW_UNLOCK = "ycbw@unlock";

        public const string YCBW_CANCELUNLOCK = "ycbw@cancelUnlock";

        public const string CROSS_RIVER_ATTACK = "crossRiver@attack";

        public const string CROSS_RIVER_FIRE = "crossRiver@fire";

        public const string CROSS_RIVER_ABANDON = "crossRiver@abandonOrcost";

        public const string CROSS_REWARD = "event@getReward";

        public const string ZONG_ZI_EAT = "zongZiWar@eat";

        public const string ZONG_ZI_GET_RANK_INFO = "zongZiWar@getRankInfo";

        public const string ZONG_ZI_SUPPORT = "zongZiWar@support";

        public const string ZONG_ZI_GET_PLAYER_PANEL = "zongZiWar@getPlayerPanel";

        public const string BX_SET_NEXT_STEP = "bx@setNextStep";

        public const string BX_SLAYGHTER = "bx@slaughter";

        public const string BX_START = "bx@start";

        public const string BX_GET_TOKEN_INFO = "bx@getTokenInfo";

        public const string BX_REPLY_TOKEN = "bx@replyToken";

        public const string BX_GET_MAIN_PANEL = "bx@getMainPanel";

        public const string BX_GET_TASK_INFO = "bx@getTaskInfo";

        public const string BX_REFRESH_TASK = "bx@refreshTask";

        public const string BX_FINISH_TASK = "bx@finishTask";

        public const string BX_GET_BIDDING_INFO = "bx@getBiddingInfo";

        public const string BX_OPEN_BOX = "bx@openBox";

        public const string BX_BID_DING = "bx@bidding";

        public const string BX_GET_NEXT_STEP = "bx@getNextStep";

        public const string WORLD_CUP_GAMBLE = "worldCup2018@gamble";

        public const string GET_DIPLOMACY_INFO = "diplomacy@getInfo";

        public const string GET_DIPLOMACY_REWARD = "diplomacy@getReward";

        public const string GET_DIPLOMACY_START = "diplomacy@openMission";

        public const string GET_DIPLOMACY_NORMAL_REWARD = "diplomacy@getNormalReward";

        public const string DUKANG_WINE_BUY = "dukangWine@buyYeast";

        public const string DUKANG_WINE_BUFF = "dukangWine@getTargetReward";

        public const string UNION_EVOKE_USE_BMT = "unionEvoke@useBmt";

        public const string DRUNKEN_CHOOSE = "drunkenFloor@getGenerals";

        public const string DRUNKEN_START = "drunkenFloor@challenge";

        public const string DRUNKEN_GENERAL = "drunkenFloor@chooseGeneral";

        public const string DRUNKEN_WINE = "drunkenFloor@drink";

        public const string DRUNKEN_WAKEUP = "drunkenFloor@wakeUp";

        public const string DRUNKEN_REWARD = "event@getReward";

        public const string ICEFIRE_GOOD = "iceFire@getGoodsInfo";

        public const string ICEFIRE_PAY_REWARD = "event@getReward";

        public const string ICEFIRE_GOOD_BUY = "iceFire@buyGoods";

        public const string ICEFIRE_REPUTE_REWARD = "iceFire@getReputeReward";

        public const string ICEFIRE_TICKET = "iceFire@useTicket";

        public const string ICEFIRE_DAY_REWARD = "iceFire@getBigReward";

        public const string ICEFIRE_DAY_GIFT = "iceFire@getFreeTicket";

        public const string HEART_BEAT_XTEST = "musics@toggle";

        public const string OPEN_RESOURE_HOME_PANEL = "folkHouse@getFolkInfo";

        public const string OPEN_RESOURE_HOME = "folkHouse@openUp";

        public const string GET_AUTO_SUPERVISOR_INFO = "autoSupervisor@getInfo";

        public const string AUTO_SUPERVISOR_BATTLE = "autoSupervisor@gzBattle";

        public const string AUTO_SUPERVISOR_GO = "autoSupervisor@handleBattle";

        public const string CAOCAO_DROP = "power@discard";

        public const string CBP_ROAR = "power@cbpRoar";

        public const string GET_GUARD_BORDER_WAR = "guardBorder@getBattleInfo";

        public const string GET_GUARD_BORDER_START = "guardBorder@search";

        public const string GET_GUARD_BORDER_ATT = "guardBorder@attack";

        public const string GET_GUARD_BORDER_ADD = "guardBorder@joinArmy";

        public const string GET_GUARD_BORDER_ATO = "guardBorder@autoJoinArmy";

        public const string GET_GUARD_BORDER_REWARD = "guardBorder@getRewardInfo";

        public const string GET_GUARD_BORDER_GET_REWARD = "event@getReward";

        public const string GET_GUARD_BORDER_GET_BIG_REWARD = "guardBorder@getBigReward";

        public const string GET_GUARD_BORDER_GET = "guardBorder@getBattleReward";

        public const string GET_GUARD_BORDER_BATTLE = "battle@replySwbgToken";

        public const string QI_GATE_GUAN_ZHEN = "qmdj@guanzhen";

        public const string QI_GATE_GAN_WU = "qmdj@ganwu";

        public const string BUY_DOUBLE_11_INFO = "double11@buyGoods";

        public const string BUY_DOUBLE_11_REWARD = "event@getReward";

        public const string BUY_DOUBLE_11_REWARD_INFO = "double11@getResouceInfo";

        public const string START_GOLD_DRAGON = "goldDragon@startAdventure";

        public const string GOLD_DRAGON_MOVE = "goldDragon@move";

        public const string GOLD_DRAGON_THROW = "goldDragon@throwDice";

        public const string GOLD_DRAGON_MAP_REWARD = "goldDragon@getMapFinalBox";

        public const string GOLD_DRAGON_INFO = "event@getInfo";

        public const string GOLD_DRAGON_BOX = "goldDragon@getReward";

        public const string LEASEHOLD_HIRE_EQUIP = "hireEquip@hire";

        public const string GET_UNITARY_REWARD = "player@getUnitaryReward";

        public const string WEI_DU_BOOTH_GET_TARGET_REWARD = "weiduBooth@getTargetReward";

        public const string EVOKE_USE_DLGJ = "evoke@useDlgj";

        public const string UNION_EVOKE_USE_DLGJ = "unionEvoke@useDlgj";

        public const string WEI_DU_BOOTH_GET_GLGJ_REWARD = "weiduBooth@getGlgjReward";

        public const string WEI_DU_BOOTH_GET_UNION_GLGJ_REWARD = "weiduBooth@getUnionGlgjReward";

        public const string ACTIVITY_SERVER_REWARD = "distroy@getWinReward";

        public const string EQUIP_1212_ITEM_USE = "equip@useDouble12Free";

        public const string EQUIP_USE_JXRY = "equip@useJxry";

        public const string ICE_MONSTER_DROP = "snowAttack@drop";

        public const string ICE_MONSTER_SPADE = "snowAttack@spade";

        public const string ICE_MONSTER_START = "snowAttack@recoverCd";

        public const string ICE_MONSTER_TARGET = "snowAttack@chooseTarget";

        public const string ICE_MONSTER_REFRESH = "snowAttack@refresh";

        public const string ICE_MONSTER_REWARD = "event@getReward";

        public const string LION_KING_REWARD = "event@getReward";

        public const string LION_KING_RANK = "lionKing@getCharts";

        public const string LION_KING_BIG_REWARD = "lionKing@getBigReward";

    }
}


