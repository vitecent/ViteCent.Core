﻿namespace ViteCent.Core;

/// <summary>
/// 拼音编码数据类，提供中文字符到拼音的映射数据
/// </summary>
public class BasePinYinCode
{
    /// <summary>
    /// 拼音编码映射数组，每个元素格式为"拼音:对应的汉字列表" 例如："a:阿啊吖嗄腌锕" 表示这些汉字的拼音都是'a'
    /// </summary>
    internal static string[] Codes =
    [
        "a:阿啊吖嗄腌锕",
        "ai:爱埃碍矮挨唉哎哀皑癌蔼艾隘捱嗳嗌嫒瑷暧砹锿霭",
        "an:安按暗岸案俺氨胺鞍谙埯揞犴庵桉铵鹌黯",
        "ang:昂肮盎",
        "ao:凹奥敖熬翱袄傲懊澳坳拗嗷岙廒遨媪骜獒聱螯鏊鳌鏖",
        "ba:把八吧巴拔霸罢爸坝芭捌扒叭笆疤跋靶耙茇菝岜灞钯粑鲅魃",
        "bai:百白败摆柏佰拜稗捭掰",
        "ban:办半板班般版拌搬斑扳伴颁扮瓣绊阪坂钣瘢癍舨",
        "bang:帮棒邦榜梆膀绑磅蚌镑傍谤蒡浜",
        "bao:报保包剥薄胞暴宝饱抱爆堡苞褒雹豹鲍葆孢煲鸨褓趵龅",
        "bei:北被倍备背辈贝杯卑悲碑钡狈惫焙孛陂邶埤萆蓓呗悖碚鹎褙鐾鞴",
        "ben:本奔苯笨畚坌贲锛",
        "beng:泵崩绷甭蹦迸嘣甏",
        "bi:比必避闭辟笔壁臂毕彼逼币鼻蔽鄙碧蓖毙毖庇痹敝弊陛匕俾荜荸薜吡哔狴庳愎滗濞弼妣婢嬖璧畀铋秕裨筚箅篦舭襞跸髀",
        "bian:变边便编遍辩扁辨鞭贬卞辫匾弁苄忭汴缏飚煸砭碥窆褊蝙笾鳊",
        "biao:标彪膘婊骠杓飑飙镖镳瘭裱鳔髟",
        "bie:别鳖憋瘪蹩",
        "bin:宾彬斌濒滨摈傧豳缤玢槟殡膑镔髌鬓",
        "bing:并病兵柄冰丙饼秉炳禀邴摒",
        "bo:波播伯拨博勃驳玻泊菠钵搏铂箔帛舶脖膊渤亳啵饽檗擘礴钹鹁簸跛踣",
        "bu:不部步布补捕卜哺埠簿怖卟逋瓿晡钚钸醭",
        "ca:擦嚓礤",
        "cai:采才材菜财裁彩猜睬踩蔡",
        "can:参残蚕灿餐惭惨孱骖璨粲黪",
        "cang:藏仓苍舱沧",
        "cao:草槽操糙曹嘈漕螬艚",
        "ce:测策侧册厕恻",
        "cen:岑涔",
        "ceng:层蹭",
        "cha:查差插察茶叉茬碴搽岔诧猹馇汊姹杈楂槎檫锸镲衩",
        "chai:柴拆豺侪钗瘥虿",
        "chan:产铲阐搀掺蝉馋谗缠颤冁谄蒇廛忏潺澶羼婵骣觇禅镡蟾躔",
        "chang:长常场厂唱肠昌倡偿畅猖尝敞伥鬯苌菖徜怅惝阊娼嫦昶氅鲳",
        "chao:朝超潮巢抄钞嘲吵炒怊晁耖",
        "che:车彻撤扯掣澈坼砗",
        "chen:陈沉称衬尘臣晨郴辰忱趁伧谌谶抻嗔宸琛榇碜龀",
        "cheng:成程称城承乘呈撑诚橙惩澄逞骋秤丞埕噌枨柽塍瞠铖铛裎蛏酲",
        "chi:持尺齿吃赤池迟翅斥耻痴匙弛驰侈炽傺坻墀茌叱哧啻嗤彳饬媸敕眵鸱瘛褫蚩螭笞篪豉踟魑",
        "chong:虫充冲崇宠茺忡憧铳舂艟",
        "chou:抽仇臭酬畴踌稠愁筹绸瞅丑俦帱惆瘳雠",
        "chu:出处除初础触楚锄储橱厨躇雏滁矗搐亍刍怵憷绌杵楮樗褚蜍蹰黜",
        "chuai:揣搋啜膪踹",
        "chuan:传船穿串川椽喘舛遄巛氚钏舡",
        "chuang:床创窗闯疮幢怆",
        "chui:吹垂锤炊捶陲棰槌",
        "chun:春纯醇椿唇淳蠢莼鹑蝽",
        "chuo:戳绰辍踔龊",
        "ci:此次刺磁雌词茨疵辞慈瓷赐茈呲祠鹚糍",
        "cong:从丛聪葱囱匆苁淙骢琮璁",
        "cou:凑楱辏腠",
        "cu:粗促醋簇蔟徂猝殂酢蹙蹴",
        "cuan:篡蹿窜汆撺爨镩",
        "cui:催脆淬粹摧崔瘁翠萃啐悴璀榱毳隹",
        "cun:存村寸忖皴",
        "cuo:错措撮磋搓挫厝嵯脞锉矬痤鹾蹉",
        "da:大打达答搭瘩耷哒嗒怛妲疸褡笪靼鞑",
        "dai:代带待袋戴呆歹傣殆贷逮怠埭甙呔岱迨骀绐玳黛",
        "dan:单但弹担蛋淡胆氮丹旦耽郸掸惮诞儋萏啖殚赕眈疸瘅聃箪",
        "dang:党当档挡荡谠凼菪宕砀裆",
        "dao:到道导刀倒稻岛捣盗蹈祷悼叨忉氘纛",
        "de:的得德锝",
        "deng:等灯登邓蹬瞪凳噔嶝戥磴镫簦",
        "di:地第低敌底帝抵滴弟递堤迪笛狄涤翟嫡蒂缔氐籴诋谛邸荻嘀娣绨柢棣觌砥碲睇镝羝骶",
        "dia:嗲",
        "dian:电点垫典店颠淀掂滇碘靛佃甸惦奠殿阽坫巅玷钿癜癫簟踮",
        "diao:调掉吊碉叼雕凋刁钓铞铫貂鲷",
        "die:迭跌爹碟蝶谍叠垤堞揲喋牒瓞耋蹀鲽",
        "ding:定顶钉丁订盯叮鼎锭仃啶玎腚碇町疔耵酊",
        "diu:丢铥",
        "dong:动东冬懂洞冻董栋侗恫垌咚岽峒氡胨胴硐鸫",
        "dou:斗豆兜抖陡逗痘蔸窦蚪篼",
        "du:度都毒独读渡杜堵镀顿督犊睹赌肚妒芏嘟渎椟牍蠹笃髑黩",
        "duan:断端段短锻缎椴煅簖",
        "dui:对队堆兑怼憝碓",
        "dun:盾吨顿蹲敦墩囤钝遁沌炖砘礅盹镦趸",
        "duo:多夺朵掇哆垛躲跺舵剁惰堕咄哚沲缍柁铎裰踱",
        "e:而二尔儿恶额恩俄耳饵蛾饿峨鹅讹娥厄扼遏鄂噩谔垩苊莪萼呃愕屙婀轭腭锇锷鹗颚鳄",
        "ei:诶",
        "en:恩蒽摁",
        "er:而二尔儿耳饵洱贰佴迩珥铒鸸鲕",
        "fa:发法阀乏伐罚筏珐垡砝",
        "fan:反翻范犯饭繁泛番凡烦返藩帆樊矾钒贩蕃蘩幡梵燔畈蹯",
        "fang:方放防访房纺仿妨芳肪坊邡枋钫舫鲂",
        "fei:非肥飞费废肺沸菲匪啡诽吠芾狒悱淝妃绯榧腓斐扉镄痱蜚篚翡霏鲱",
        "fen:分粉奋份粪纷芬愤酚吩氛坟焚汾忿偾瀵棼鲼鼢",
        "feng:风封蜂丰缝峰锋疯奉枫烽逢冯讽凤俸酆葑唪沣砜",
        "fou:否缶",
        "fu:复服副府夫负富附福伏符幅腐浮辅付腹妇孵覆扶辐傅佛缚父弗甫肤氟敷拂俘涪袱抚俯釜斧脯腑赴赋阜讣咐匐凫郛芙苻茯莩菔拊呋幞怫滏艴孚驸绂绋桴赙祓砩黻黼罘稃馥蚨蜉蝠蝮麸趺跗鲋鳆",
        "ga:噶嘎尬尕尜旮钆",
        "gai:改该盖概钙溉丐陔垓戤赅",
        "gan:干杆感敢赶甘肝秆柑竿赣坩苷尴擀泔淦澉绀橄旰矸疳酐",
        "gang:刚钢缸纲岗港杠冈肛戆罡筻",
        "gao:高搞告稿膏篙皋羔糕镐睾诰郜藁缟槔槁杲锆",
        "ge:个各革格割歌隔哥铬阁戈葛搁鸽胳疙蛤鬲仡哿圪塥嗝搿膈硌镉袼虼舸骼",
        "gen:根跟亘茛哏艮",
        "geng:更耕颈庚羹埂耿梗哽赓绠鲠",
        "gong:工公共供功攻巩贡汞宫恭龚躬弓拱珙肱蚣觥",
        "gou:够构沟狗钩勾购苟垢佝诟岣遘媾缑枸觏彀笱篝鞲",
        "gu:鼓固古骨故顾股谷估雇孤姑辜菇咕箍沽蛊嘏诂菰崮汩梏轱牯牿臌毂瞽罟钴锢鸪痼蛄酤觚鲴鹘",
        "gua:挂刮瓜剐寡褂卦诖呱栝胍鸹",
        "guai:怪乖拐",
        "guan:关管观官灌贯惯冠馆罐棺倌莞掼涫盥鹳矜鳏",
        "guang:光广逛咣犷桄胱",
        "gui:规贵归硅鬼轨龟桂瑰圭闺诡癸柜跪刽匦刿庋宄妫桧炅晷皈簋鲑鳜",
        "gun:滚辊棍衮绲磙鲧",
        "guo:国过果锅郭裹馘埚掴呙帼崞猓椁虢聒蜾蝈",
        "ha:哈铪",
        "hai:还海害孩骸氦亥骇嗨胲醢",
        "han:含焊旱喊汉寒汗函韩酣憨邯涵罕翰撼捍憾悍邗菡撖阚瀚晗焓顸颔蚶鼾",
        "hang:航夯杭沆绗珩颃",
        "hao:好号毫耗豪郝浩壕嚎蒿薅嗥嚆濠灏昊皓颢蚝",
        "he:和合河何核赫荷褐喝贺呵禾盒菏貉阂涸鹤诃劾壑嗬阖纥曷盍颌蚵翮",
        "hei:黑嘿",
        "hen:很狠痕恨",
        "heng:横衡恒哼亨蘅桁",
        "hong:红洪轰烘哄虹鸿宏弘黉訇讧荭蕻薨闳泓",
        "hou:后候厚侯喉猴吼堠後逅瘊篌糇鲎骺",
        "hu:护互湖呼户弧乎胡糊虎忽瑚壶葫蝴狐唬沪冱唿囫岵猢怙惚浒滹琥槲轷觳烀煳戽扈祜瓠鹄鹕鹱笏醐斛",
        "hua:化花话划滑华画哗猾骅桦砉铧",
        "huai:坏怀淮槐徊踝",
        "huan:环换欢缓患幻焕桓唤痪豢涣宦郇奂萑擐圜獾洹浣漶寰逭缳锾鲩鬟",
        "huang:黄簧荒皇慌蝗磺凰惶煌晃幌恍谎隍徨湟潢遑璜肓癀蟥篁鳇",
        "hui:会回灰挥辉汇毁慧恢绘惠徽蛔悔卉晦贿秽烩讳诲诙茴荟蕙咴哕喙隳洄浍彗缋珲晖恚虺蟪麾",
        "hun:混浑荤昏婚魂诨馄阍溷",
        "huo:活或火货获伙霍豁惑祸劐藿攉嚯夥钬锪镬耠蠖",
        "ji:级及机极几积给基记己计集即际季激济技击继急剂既纪寄挤鸡迹绩吉脊辑籍疾肌棘畸圾稽箕饥讥姬缉汲嫉蓟冀伎祭悸寂忌妓藉丌亟乩剞佶偈诘墼芨芰荠蒺蕺掎叽咭哜唧岌嵴洎屐骥畿玑楫殛戟戢赍觊犄齑矶羁嵇稷瘠虮笈笄暨跻跽霁鲚鲫髻麂",
        "jia:加家架价甲夹假钾贾稼驾嘉枷佳荚颊嫁伽郏葭岬浃迦珈戛胛恝铗镓痂瘕袷蛱笳袈跏",
        "jian:间件见建坚减检践尖简碱剪艰渐肩健柬鉴剑歼监兼奸箭茧舰俭笺煎缄硷拣捡荐槛贱饯溅涧僭谏谫菅蒹搛湔蹇謇缣枧楗戋戬牮犍毽腱睑锏鹣裥笕翦趼踺鲣鞯",
        "jiang:将降讲江浆蒋奖疆僵姜桨匠酱茳洚绛缰犟礓耩糨豇",
        "jiao:较教交角叫脚胶浇焦搅酵郊铰窖椒礁骄娇嚼矫侥狡饺缴绞剿轿佼僬艽茭挢噍峤徼姣敫皎鹪蛟醮跤鲛",
        "jie:结阶解接节界截介借届街揭洁杰竭皆秸劫桔捷睫姐戒藉芥疥诫讦拮喈嗟婕孑桀碣疖颉蚧羯鲒骱",
        "jin:进金近紧斤今尽仅劲浸禁津筋锦晋巾襟谨靳烬卺荩堇噤馑廑妗缙瑾槿赆觐衿",
        "jing:经精京径井静竟晶净境镜景警茎敬惊睛竞荆兢鲸粳痉靖刭儆阱菁獍憬泾迳弪婧肼胫腈旌",
        "jiong:炯窘迥扃",
        "jiu:就九旧究久救酒纠揪玖韭灸厩臼舅咎疚僦啾阄柩桕鸠鹫赳鬏",
        "ju:具据局举句聚距巨居锯剧矩拒鞠拘狙疽驹菊咀沮踞俱惧炬倨讵苣苴莒掬遽屦琚椐榘榉橘犋飓钜锔窭裾趄醵踽龃雎鞫",
        "juan:卷捐鹃娟倦眷绢鄄狷涓桊蠲锩镌隽",
        "jue:决觉绝掘撅攫抉倔爵诀厥劂谲矍蕨噘噱崛獗孓珏桷橛爝镢蹶觖",
        "jun:军均菌君钧峻俊竣浚郡骏捃皲筠麇",
        "ka:卡喀咖咯佧咔胩",
        "kai:开凯揩楷慨剀垲蒈忾恺铠锎锴",
        "kan:看刊坎堪勘砍侃莰戡龛瞰",
        "kang:抗康炕慷糠扛亢伉闶钪",
        "kao:考靠拷烤尻栲犒铐",
        "ke:可克科刻客壳颗棵柯坷苛磕咳渴课嗑岢恪溘骒缂珂轲氪瞌钶锞稞疴窠颏蝌髁",
        "ken:肯啃垦恳裉",
        "keng:坑吭铿",
        "kong:孔空控恐倥崆箜",
        "kou:口扣抠寇芤蔻叩眍筘",
        "ku:苦库枯酷哭窟裤刳堀喾绔骷",
        "kua:跨夸垮挎胯侉",
        "kuai:快块筷侩蒯郐哙狯脍",
        "kuan:宽款髋",
        "kuang:况矿狂框匡筐眶旷诓诳邝圹夼哐纩贶",
        "kui:奎溃馈亏盔岿窥葵魁傀愧馗匮夔隗蒉揆喹喟悝愦逵暌睽聩蝰篑跬",
        "kun:困昆坤捆悃阃琨锟醌鲲髡",
        "kuo:扩括阔廓蛞",
        "la:拉啦蜡腊蓝垃喇辣剌邋旯砬瘌",
        "lai:来赖莱崃徕涞濑赉睐铼癞籁",
        "lan:兰烂蓝览栏婪拦篮阑澜谰揽懒缆滥岚漤榄斓罱镧褴",
        "lang:浪朗郎狼琅榔廊莨蒗啷阆锒稂螂",
        "lao:老劳牢涝捞佬姥酪烙唠崂栳铑铹痨耢醪",
        "le:了乐勒肋仂叻泐鳓",
        "lei:类雷累垒泪镭蕾磊儡擂肋羸诔嘞嫘缧檑耒酹",
        "leng:冷棱楞塄愣",
        "li:理里利力立离例历粒厘礼李隶黎璃励犁梨丽厉篱狸漓鲤莉荔吏栗砾傈俐痢沥哩俪俚郦坜苈莅蓠藜呖唳喱猁溧澧逦娌嫠骊缡枥栎轹戾砺詈罹锂鹂疠疬蛎蜊蠡笠篥粝醴跞雳鲡鳢黧",
        "lia:俩",
        "lian:连联练炼脸链莲镰廉怜涟帘敛恋蔹奁潋濂琏楝殓臁裢裣蠊鲢",
        "liang:量两粮良亮梁凉辆粱晾谅墚椋踉靓魉",
        "liao:料疗辽僚撩聊燎寥潦撂镣廖蓼尥嘹獠寮缭钌鹩",
        "lie:列裂烈劣猎冽埒捩咧洌趔躐鬣",
        "lin:林磷临邻淋麟琳霖鳞凛赁吝蔺啉嶙廪懔遴檩辚膦瞵粼躏",
        "ling:领另零令灵岭铃龄凌陵拎玲菱伶羚酃苓呤囹泠绫柃棂瓴聆蛉翎鲮",
        "liu:流六留刘硫柳馏瘤溜琉榴浏遛骝绺旒熘锍镏鹨鎏",
        "long:龙垄笼隆聋咙窿拢陇垅茏泷珑栊胧砻癃",
        "lou:漏楼娄搂篓陋偻蒌喽嵝镂瘘耧蝼髅",
        "lu:路率露绿炉律虑滤陆氯鲁铝录旅卢吕芦颅庐掳卤虏麓碌赂鹿潞禄戮驴侣履屡缕垆撸噜闾泸渌漉逯璐栌榈橹轳辂辘氇胪膂镥稆鸬鹭褛簏舻鲈",
        "luan:卵乱峦挛孪滦脔娈栾鸾銮",
        "lue:略掠锊",
        "lun:论轮伦抡仑沦纶囵",
        "luo:落罗螺洛络逻萝锣箩骡裸骆倮蠃荦捋摞猡泺漯珞椤脶镙瘰雒",
        "m:呒",
        "ma:马麻吗妈骂嘛码玛蚂唛犸嬷杩蟆",
        "mai:麦脉卖买埋迈劢荬霾",
        "man:满慢曼漫蔓瞒馒蛮谩墁幔缦熳镘颟螨鳗鞔",
        "mang:忙芒盲茫氓莽邙漭硭蟒",
        "mao:毛矛冒貌贸帽猫茅锚铆卯茂袤茆峁泖瑁昴牦耄旄懋瞀蟊髦",
        "me:么麽",
        "mei:没每美煤霉酶梅妹眉玫枚媒镁昧寐媚莓嵋猸浼湄楣镅鹛袂魅",
        "men:们门闷扪焖懑钔",
        "meng:孟猛蒙盟梦萌锰檬勐甍瞢懵朦礞虻蜢蠓艋艨",
        "mi:米密迷蜜秘眯醚靡糜谜弥觅泌幂芈谧蘼咪嘧猕汨宓弭脒祢敉糸縻麋",
        "mian:面棉免绵眠冕勉娩缅沔渑湎腼眄",
        "miao:苗秒描庙妙瞄藐渺喵邈缈缪杪淼眇鹋",
        "mie:灭蔑咩蠛篾",
        "min:民敏抿皿悯闽苠岷闵泯缗玟珉愍黾鳘",
        "ming:命明名鸣螟铭冥茗溟暝瞑酩",
        "miu:谬",
        "mo:磨末模膜摸墨摩莫抹默摹蘑魔沫漠寞陌谟茉蓦馍嫫殁镆秣瘼耱貊貘",
        "mou:某谋牟侔哞眸蛑蝥鍪",
        "mu:亩目木母墓幕牧姆穆拇牡暮募慕睦仫坶苜沐毪钼",
        "n:嗯",
        "na:那南哪拿纳钠呐娜捺肭镎衲",
        "nai:耐奶乃氖奈鼐艿萘柰",
        "nan:南难男喃囝囡楠腩蝻赧",
        "nang:囊攮囔馕曩",
        "nao:脑闹挠恼淖孬垴呶猱瑙硇铙蛲",
        "ne:呢讷",
        "nei:内馁",
        "nen:嫩恁",
        "neng:能",
        "ni:你泥尼逆拟尿妮霓倪匿腻溺伲坭猊怩昵旎慝睨铌鲵",
        "nian:年念粘蔫拈碾撵捻酿廿埝辇黏鲇鲶",
        "niang:娘",
        "niao:尿鸟茑嬲脲袅",
        "nie:镍啮涅捏聂孽镊乜陧蘖嗫颞臬蹑",
        "nin:您",
        "ning:宁凝拧柠狞泞佞苎咛甯聍",
        "niu:牛扭钮纽狃忸妞",
        "nong:农弄浓脓侬哝",
        "nou:耨",
        "nu:女奴努怒弩胬孥驽恧钕衄",
        "nuan:暖",
        "nue:虐",
        "nuo:诺挪懦糯傩搦喏锘",
        "o:欧偶哦鸥殴藕呕沤讴噢怄瓯耦",
        "ou:欧偶鸥殴藕呕沤讴怄瓯耦",
        "pa:怕派爬帕啪趴琶葩杷筢",
        "pai:派排拍牌哌徘湃俳蒎",
        "pan:判盘叛潘攀磐盼畔胖爿泮袢襻蟠蹒",
        "pang:旁乓庞耪胖彷滂逄螃",
        "pao:跑炮刨抛泡咆袍匏狍庖脬疱",
        "pei:配培陪胚呸裴赔佩沛辔帔旆锫醅霈",
        "pen:喷盆湓",
        "peng:碰棚蓬朋捧膨砰抨烹澎彭硼篷鹏堋嘭怦蟛",
        "pi:批皮坯脾疲砒霹披劈琵毗啤匹痞僻屁譬丕仳陴邳郫圮鼙芘擗噼庀淠媲纰枇甓睥罴铍癖疋蚍蜱貔",
        "pian:片偏篇骗谝骈犏胼翩蹁",
        "piao:票漂飘瓢剽嘌嫖缥殍瞟螵",
        "pie:撇瞥丿苤氕",
        "pin:品贫频拼苹聘拚姘嫔榀牝颦",
        "ping:平评瓶凭苹乒坪萍屏俜娉枰鲆",
        "po:破迫坡泼颇婆魄粕叵鄱珀攴钋钷皤笸",
        "pou:剖裒掊",
        "pu:普谱扑埔铺葡朴蒲仆莆菩圃浦曝瀑匍噗溥濮璞氆镤镨蹼",
        "qi:起其气期七器齐奇汽企漆欺旗畦启弃歧栖戚妻凄柒沏棋崎脐祈祁骑岂乞契砌迄泣讫亓俟圻芑芪萁萋葺蕲嘁屺岐汔淇骐绮琪琦杞桤槭耆欹祺憩碛颀蛴蜞綦綮蹊鳍麒",
        "qia:恰掐洽葜髂",
        "qian:前千钱浅签迁铅潜牵钳谴扦钎仟谦乾黔遣堑嵌欠歉倩佥阡芊芡茜荨掮岍悭慊骞搴褰缱椠肷愆钤虔箬箝",
        "qiang:强枪抢墙腔呛羌蔷戕嫱樯戗炝锖锵镪襁蜣羟跄",
        "qiao:桥瞧巧敲乔蕉橇锹悄侨鞘撬翘峭俏窍劁诮谯荞愀憔樵硗跷鞒",
        "qie:切且茄怯窃郄惬妾挈锲箧",
        "qin:亲侵勤秦钦琴芹擒禽寝沁芩揿吣嗪噙溱檎锓覃螓衾",
        "qing:情清青轻倾请庆氢晴卿擎氰顷苘圊檠磬蜻罄箐謦鲭黥",
        "qiong:穷琼邛茕穹蛩筇跫銎",
        "qiu:求球秋丘邱囚酋泅俅巯犰湫逑遒楸赇虬蚯蝤裘糗鳅鼽",
        "qu:去区取曲渠屈趋驱趣蛆躯娶龋诎劬蕖蘧岖衢阒璩觑氍朐祛磲鸲癯蛐蠼麴瞿黢",
        "quan:全权圈劝泉醛颧痊拳犬券诠荃悛绻辁畎铨蜷筌鬈",
        "que:确却缺炔瘸鹊榷雀阕阙悫",
        "qun:群裙逡",
        "ran:然燃染冉苒蚺髯",
        "rang:让壤嚷瓤攘禳穰",
        "rao:绕扰饶荛娆桡",
        "re:热惹",
        "ren:人认任仁刃忍壬韧妊纫仞荏葚饪轫稔衽",
        "reng:仍扔",
        "ri:日",
        "rong:容溶荣熔融绒戎茸蓉冗嵘狨榕肜蝾",
        "rou:肉揉柔糅蹂鞣",
        "ru:如入儒乳茹蠕孺辱汝褥蓐薷嚅洳溽濡缛铷襦颥",
        "ruan:软阮朊",
        "rui:瑞锐蕊芮蕤枘睿蚋",
        "run:润闰",
        "ruo:弱若偌",
        "sa:撒萨洒卅仨挲脎飒",
        "sai:塞赛腮鳃噻",
        "san:三散叁伞馓毵糁",
        "sang:桑丧嗓搡磉颡",
        "sao:扫搔骚嫂埽缫缲臊瘙鳋",
        "se:色瑟涩啬铯穑",
        "sen:森",
        "seng:僧",
        "sha:沙杀砂啥纱莎刹傻煞杉唼歃铩痧裟霎鲨",
        "shai:筛晒",
        "shan:山闪善珊扇陕苫杉删煽衫擅赡膳汕缮剡讪鄯埏芟潸姗嬗骟膻钐疝蟮舢跚鳝",
        "shang:上商伤尚墒赏晌裳垧绱殇熵觞",
        "shao:少烧稍绍哨梢捎芍勺韶邵劭苕潲蛸筲艄",
        "she:社设射摄舌涉舍蛇奢赊赦慑厍佘猞滠歙畲麝",
        "shen:深身神伸甚渗沈肾审申慎砷呻娠绅婶诜谂莘哂渖椹胂矧蜃",
        "sheng:生胜声省升盛绳剩圣牲甥嵊晟眚笙",
        "shi:是时十使事实式识世试石什示市史师始施士势湿适食失视室氏蚀诗释拾饰驶狮尸虱矢屎柿拭誓逝嗜噬仕侍恃谥埘莳蓍弑轼贳炻铈螫舐筮酾豕鲥鲺",
        "shou:手受收首守授寿兽售瘦狩绶艏",
        "shu:数书树属术输述熟束鼠疏殊舒蔬薯叔署枢梳抒淑赎孰暑曙蜀黍戍竖墅庶漱恕丨倏塾菽摅沭澍姝纾毹腧殳秫",
        "shua:刷耍唰",
        "shuai:衰帅摔甩蟀",
        "shuan:栓拴闩涮",
        "shuang:双霜爽孀",
        "shui:水谁睡税",
        "shun:顺吮瞬舜",
        "shuo:说硕朔烁蒴搠妁槊铄",
        "si:四思死斯丝似司饲私撕嘶肆寺嗣伺巳厮兕厶咝汜泗澌姒驷缌祀锶鸶耜蛳笥",
        "song:松送宋颂耸怂讼诵凇菘崧嵩忪悚淞竦",
        "sou:搜艘擞嗽叟薮嗖嗾馊溲飕瞍锼螋",
        "su:素速苏塑缩俗诉宿肃酥粟僳溯夙谡蔌嗉愫涑簌觫稣",
        "suan:算酸蒜狻",
        "sui:随穗碎虽岁隋绥髓遂隧祟谇荽濉邃燧眭睢",
        "sun:损孙笋荪狲飧榫隼",
        "suo:所缩锁索蓑梭唆琐唢嗦嗍娑桫睃羧",
        "ta:他它她塔踏塌獭挞蹋闼溻遢榻沓铊趿鳎",
        "tai:台太态胎抬泰苔酞汰邰薹肽炱钛跆鲐",
        "tan:谈碳探炭坦贪滩坍摊瘫坛檀痰潭谭毯袒叹郯澹昙忐钽锬",
        "tang:堂糖唐塘汤搪棠膛倘躺淌趟烫傥帑溏瑭樘铴镗耥螗螳羰醣",
        "tao:套讨逃陶萄桃掏涛滔绦淘鼗啕洮韬焘饕",
        "te:特忒忑铽",
        "teng:腾疼藤誊滕",
        "ti:提题体替梯惕剔踢锑蹄啼嚏涕剃屉倜悌逖缇鹈裼醍",
        "tian:天田添填甜恬舔腆掭忝阗殄畋",
        "tiao:条跳挑迢眺佻祧窕蜩笤粜龆鲦髫",
        "tie:铁贴帖萜餮",
        "ting:听停庭挺廷厅烃汀亭艇莛葶婷梃铤蜓霆",
        "tong:同通统铜痛筒童桶桐酮瞳彤捅佟仝茼嗵恸潼砼",
        "tou:头投透偷钭骰",
        "tu:图土突途徒凸涂吐兔屠秃堍荼菟钍酴",
        "tuan:团湍抟彖疃",
        "tui:推退腿颓蜕褪煺",
        "tun:吞屯臀氽饨暾豚",
        "tuo:脱拖托妥椭鸵陀驮驼拓唾乇佗坨庹沱柝橐砣箨酡跎鼍",
        "wa:瓦挖哇蛙洼娃袜佤娲腽",
        "wai:外歪",
        "wan:完万晚弯碗顽湾挽玩豌丸烷皖惋宛婉腕剜芄菀纨绾琬脘畹蜿",
        "wang:往王望网忘妄亡旺汪枉罔尢惘辋魍",
        "wei:为位委围维唯卫微伟未威危尾谓喂味胃魏伪违韦畏纬巍桅惟潍苇萎蔚渭尉慰偎诿隈葳薇囗帏帷崴嵬猥猬闱沩洧涠逶娓玮韪軎炜煨痿艉鲔",
        "wen:问温文稳纹闻蚊瘟吻紊刎阌汶璺雯",
        "weng:嗡翁瓮蓊蕹",
        "wo:我握窝蜗涡沃挝卧斡倭莴喔幄渥肟硪龌",
        "wu:无五物武务误伍舞污悟雾午屋乌吴诬钨巫呜芜梧吾毋捂侮坞戊晤勿兀仵阢邬圬芴唔庑怃忤浯寤迕妩婺骛杌牾焐鹉鹜痦蜈鋈鼯",
        "xi:系席西习细吸析喜洗铣稀戏隙希息袭锡烯牺悉惜溪昔熙硒矽晰嘻膝夕熄汐犀檄媳僖兮隰郗菥葸蓰奚唏徙饩阋浠淅屣嬉玺樨曦觋欷熹禊禧皙穸蜥螅蟋舄舾羲粞翕醯鼷",
        "xia:下夏吓狭霞瞎虾匣辖暇峡侠厦呷狎遐瑕柙硖罅黠",
        "xian:线现先县限显鲜献险陷宪纤掀弦腺锨仙咸贤衔舷闲涎嫌馅羡冼苋莶藓岘猃暹娴氙燹祆鹇痫蚬筅籼酰跣跹霰",
        "xiang:想向相象响项箱乡香像详橡享湘厢镶襄翔祥巷芗葙饷庠骧缃蟓鲞飨",
        "xiao:小消削效笑校销硝萧肖孝霄哮嚣宵淆晓啸哓崤潇逍骁绡枭枵筱箫魈",
        "xie:些写斜谢协械卸屑鞋歇邪胁蟹泄泻楔蝎挟携谐懈偕亵勰燮薤撷獬廨渫瀣邂绁缬榭榍躞",
        "xin:新心信锌芯辛欣薪忻衅囟馨昕歆鑫",
        "xing:行性形型星兴醒姓幸腥猩惺刑邢杏陉荇荥擤饧悻硎",
        "xiong:雄胸兄凶熊匈汹芎",
        "xiu:修锈休袖秀朽羞嗅绣咻岫馐庥溴鸺貅髹",
        "xu:续许须需序虚絮畜叙蓄绪徐墟戌嘘酗旭恤婿诩勖圩蓿洫溆顼栩煦盱胥糈醑",
        "xuan:选旋宣悬玄轩喧癣眩绚儇谖萱揎泫渲漩璇楦暄炫煊碹铉镟痃",
        "xue:学血雪穴靴薛谑泶踅鳕",
        "xun:训旬迅讯寻循巡勋熏询驯殉汛逊巽埙荀蕈薰峋徇獯恂洵浔曛醺鲟",
        "ya:压亚呀牙芽雅蚜鸭押鸦丫崖衙涯哑讶伢垭揠岈迓娅琊桠氩砑睚痖",
        "yan:验研严眼言盐演岩沿烟延掩宴炎颜燕衍焉咽阉淹蜒阎奄艳堰厌砚雁唁彦焰谚厣赝俨偃兖谳郾鄢菸崦恹闫阏湮滟妍嫣琰檐晏胭焱罨筵酽魇餍鼹",
        "yang:样养氧扬洋阳羊秧央杨仰殃鸯佯疡痒漾徉怏泱炀烊恙蛘鞅",
        "yao:要药摇腰咬邀耀疟妖瑶尧遥窑谣姚舀夭爻吆崾徭幺珧杳轺曜肴鹞窈繇鳐",
        "ye:也业页叶液夜野爷冶椰噎耶掖曳腋靥谒邺揶晔烨铘",
        "yi:一以义意已移医议依易乙艺益异宜仪亿遗伊役衣疑亦谊翼译抑忆疫壹揖铱颐夷胰沂姨彝椅蚁倚矣邑屹臆逸肄裔毅溢诣翌绎刈劓佚佾诒圯埸懿苡荑薏弈奕挹弋呓咦咿噫峄嶷猗饴怿怡悒漪迤驿缢殪轶贻旖熠眙钇镒镱痍瘗癔翊蜴舣羿翳酏黟",
        "yin:因引阴印音银隐饮荫茵殷姻吟淫寅尹胤鄞垠堙茚吲喑狺夤洇氤铟瘾窨蚓霪龈",
        "ying:应影硬营英映迎樱婴鹰缨莹萤荧蝇赢盈颖嬴郢茔莺萦蓥撄嘤膺滢潆瀛瑛璎楹媵鹦瘿颍罂",
        "yo:哟唷",
        "yong:用勇永拥涌蛹庸佣臃痈雍踊咏泳恿俑壅墉喁慵邕镛甬鳙饔",
        "you:有由又油右友优幼游尤诱犹幽悠忧邮铀酉佑釉卣攸侑莠莜莸呦囿宥柚猷牖铕疣蚰蚴蝣鱿黝鼬",
        "yu:于与育鱼雨玉余遇预域语愈渔予羽愚御欲宇迂淤盂榆虞舆俞逾愉渝隅娱屿禹芋郁吁喻峪狱誉浴寓裕豫驭禺毓伛俣谀谕萸蓣揄圄圉嵛狳饫馀庾阈鬻妪妤纡瑜昱觎腴欤於煜熨燠聿钰鹆鹬瘐瘀窬窳蜮蝓竽臾舁雩龉",
        "yuan:员原圆源元远愿院缘援园怨鸳渊冤垣袁辕猿苑垸塬芫掾沅媛瑗橼爰眢鸢螈箢鼋",
        "yue:月越约跃曰阅钥岳粤悦龠瀹樾刖钺",
        "yun:运云匀允孕耘郧陨蕴酝晕韵郓芸狁恽愠纭韫殒昀氲熨",
        "za:杂咱匝砸咋咂",
        "zai:在再载栽灾哉宰崽甾",
        "zan:赞咱暂攒拶瓒昝簪糌趱錾",
        "zang:脏葬赃奘驵臧",
        "zao:造早遭燥凿糟枣皂藻澡蚤躁噪灶唣",
        "ze:则择责泽仄赜啧帻迮昃笮箦舴",
        "zei:贼",
        "zen:怎谮",
        "zeng:增曾憎赠缯甑罾锃",
        "zha:扎炸闸铡轧渣喳札眨栅榨乍诈揸吒咤哳砟痄蚱齄",
        "zhai:寨摘窄斋宅债砦瘵",
        "zhan:战展站占瞻毡詹沾盏斩辗崭蘸栈湛绽谵搌旃",
        "zhang:张章掌仗障胀涨账樟彰漳杖丈帐瘴仉鄣幛嶂獐嫜璋蟑",
        "zhao:照找招召赵爪罩沼兆昭肇诏棹钊笊",
        "zhe:这着者折哲浙遮蛰辙锗蔗谪摺柘辄磔鹧褶蜇赭",
        "zhen:真针阵镇振震珍诊斟甄砧臻贞侦枕疹圳蓁浈缜桢榛轸赈胗朕祯畛稹鸩箴",
        "zheng:争正政整证征蒸症郑挣睁狰怔拯帧诤峥徵钲铮筝",
        "zhi:之制治只质指直支织止至置志知执职植纸致枝殖脂智肢秩址滞汁芝吱蜘侄趾旨挚掷帜峙稚炙痔窒卮陟郅埴芷摭帙忮彘咫骘栉枳栀桎轵轾贽胝膣祉祗黹雉鸷痣蛭絷酯跖踬踯豸觯",
        "zhong:中种重众钟终忠肿仲盅衷冢锺螽舯踵",
        "zhou:轴周洲州皱骤舟诌粥肘帚咒宙昼荮啁妯纣绉胄碡籀酎",
        "zhu:主注著住助猪铸株筑柱驻逐祝竹贮珠朱诸蛛诛烛煮拄瞩嘱蛀伫侏邾茱洙渚潴杼槠橥炷铢疰瘃竺箸舳翥躅麈",
        "zhua:抓",
        "zhuai:拽",
        "zhuan:转专砖撰赚篆啭馔颛",
        "zhuang:装状壮庄撞桩妆僮",
        "zhui:追锥椎赘坠缀惴骓缒",
        "zhun:准谆肫窀",
        "zhuo:捉桌拙卓琢茁酌啄灼浊倬诼擢浞涿濯焯禚斫镯",
        "zi:子自资字紫仔籽姿兹咨滋淄孜滓渍谘嵫姊孳缁梓辎赀恣眦锱秭耔笫粢趑觜訾龇鲻髭",
        "zong:总纵宗综棕鬃踪偬枞腙粽",
        "zou:走邹奏揍诹陬鄹驺鲰",
        "zu:组族足阻祖租卒诅俎菹镞",
        "zuan:钻纂攥缵躜",
        "zui:最罪嘴醉蕞",
        "zun:尊遵撙樽鳟",
        "zuo:作做左座坐昨佐柞阼唑嘬怍胙祚"
    ];
}