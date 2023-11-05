using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

internal class Decryptor
{
	static Decryptor()
	{
		uint num = 720U;
		uint[] array = new uint[]
		{
			2713168441U, 191232663U, 3256589321U, 304417386U, 3289489729U, 327468528U, 4239185562U, 1279680148U, 802796148U, 1941019461U,
			1440734347U, 1642589099U, 214392484U, 4039335699U, 1557402313U, 1579992348U, 1223070224U, 525364102U, 1028748309U, 601804172U,
			69482967U, 2761300977U, 1865822089U, 2191224589U, 1663162811U, 2693345575U, 3228562717U, 1522924705U, 1091380676U, 774838909U,
			932704172U, 1305644775U, 1841785497U, 506302496U, 3357147907U, 3184589228U, 531121861U, 610286931U, 625194842U, 3491334195U,
			525331940U, 178725258U, 448158876U, 3209404659U, 1077116086U, 1664890950U, 3312405524U, 4118899298U, 1145924935U, 2389661397U,
			3443929102U, 3215956401U, 3232401839U, 2756337713U, 2440124178U, 3787901000U, 3120874393U, 2043354252U, 2973254371U, 3588368744U,
			1091677784U, 2158311206U, 898910470U, 481678400U, 1607978298U, 241037406U, 2002890276U, 4229710588U, 99911434U, 1744975587U,
			516489585U, 2169318918U, 2497932785U, 3465841698U, 2630924666U, 2914999175U, 1971068018U, 3987264522U, 2399653004U, 2619110589U,
			2390543441U, 2867473162U, 2781856153U, 503190087U, 1017812165U, 848697592U, 512439863U, 2982393136U, 2263193387U, 2686228921U,
			1032386825U, 2570273230U, 2654405793U, 2424908492U, 185567252U, 1785858693U, 3612854344U, 1511629317U, 1837369943U, 507837545U,
			3170100316U, 230439060U, 3636903989U, 2896115212U, 4128380108U, 2151961743U, 1171851210U, 1382979027U, 3526862745U, 1838829648U,
			2020689068U, 3043538628U, 1824697116U, 1051268538U, 2878039692U, 61253654U, 2759052907U, 3572223848U, 288036746U, 2111945573U,
			3751141897U, 2568256013U, 2362995443U, 4262669921U, 2375330214U, 263407484U, 682961141U, 8216668U, 1898010733U, 69320309U,
			2801323518U, 3525759494U, 3498590698U, 3071580799U, 4216020638U, 1998409684U, 2225791238U, 413912787U, 2136247892U, 1587213485U,
			3098835343U, 784669479U, 839778385U, 2510995427U, 3005460665U, 3557339801U, 2548384233U, 153052794U, 3129414474U, 898426391U,
			2910343081U, 773654448U, 468324815U, 3823292081U, 150883823U, 3599037755U, 3599439590U, 2760676337U, 2466197023U, 3250978304U,
			315435311U, 3475259897U, 1508663678U, 42213368U, 2500621933U, 1635282050U, 1909795297U, 2561098530U, 2137134195U, 3593328032U,
			2632836361U, 3652719307U, 1406231600U, 2023809457U, 3550083215U, 2195529791U, 4046711983U, 185138338U, 1894181695U, 2059268188U,
			3241593944U, 2482637054U, 1929721933U, 1969225394U, 3541327782U, 2745153241U, 3704573815U, 560156063U, 1526240556U, 629626448U,
			2315074583U, 2758395111U, 1962267486U, 3210047969U, 4113187511U, 345844079U, 1898526712U, 2576384233U, 777873405U, 3728055460U,
			921197942U, 516562972U, 1013301274U, 3062812604U, 1411171211U, 634563161U, 741992258U, 622370030U, 50947304U, 2832195866U,
			742060597U, 3300240672U, 4222319067U, 1618066831U, 113855153U, 4132519844U, 1571507590U, 1299487122U, 478755912U, 3985941925U,
			2284568996U, 3247244483U, 2568130476U, 3741327339U, 2120331146U, 6595058U, 369940530U, 1857531173U, 2846239379U, 4164204751U,
			982826521U, 2304073253U, 2530415222U, 3969780903U, 741345097U, 2011367280U, 3494719549U, 1039153552U, 676450675U, 2804117089U,
			3155844904U, 2853494135U, 1653190476U, 303140837U, 557200210U, 3745277757U, 3459976141U, 636670481U, 1423821741U, 874196803U,
			517736683U, 2887973923U, 3409018975U, 2375718261U, 1075144987U, 151249192U, 4074902180U, 1532892826U, 2368422086U, 263015705U,
			3559837871U, 2676453003U, 2835982903U, 2459949190U, 2948699080U, 4151802268U, 507254946U, 1507332177U, 3623003379U, 2698394158U,
			278567431U, 3849721784U, 3728384701U, 3646004301U, 4162333807U, 473980479U, 2889918071U, 3486341839U, 1080782929U, 1860661723U,
			368352711U, 2214038520U, 1238139871U, 4029463514U, 2045473183U, 3282548776U, 2159609140U, 33258899U, 2561356774U, 1198726829U,
			3616677227U, 467438355U, 2671960415U, 1101250700U, 4105759881U, 2344175946U, 921572856U, 22702933U, 745192417U, 3537340831U,
			1317479557U, 684405674U, 215920189U, 2182168420U, 3554598386U, 1943399681U, 3304533918U, 3121385118U, 885634989U, 2445668697U,
			2970380141U, 3291204923U, 252534578U, 1622591852U, 3477335009U, 2746256893U, 17653931U, 2628882365U, 201406212U, 1186053310U,
			1728862526U, 1558976606U, 1056362891U, 1370198078U, 3704790702U, 3836761968U, 2386555291U, 3204231952U, 2673627963U, 2603379794U,
			1151498917U, 916219352U, 2618925481U, 220827877U, 1367452727U, 1318277354U, 732000870U, 1845147013U, 2577843647U, 301313535U,
			2841256171U, 1709821187U, 3839708029U, 3742878532U, 2071111910U, 4153162459U, 1342613109U, 1227595222U, 2771773792U, 498408053U,
			2824835033U, 2870926955U, 2884408546U, 1461401335U, 4000044856U, 1434119528U, 4275917440U, 2484202765U, 662908958U, 510885937U,
			2886842977U, 814286641U, 2122283133U, 754898645U, 2685320416U, 3261868822U, 4116714271U, 2963810267U, 2274627979U, 357264287U,
			3340805460U, 1192804309U, 1952863983U, 4075841458U, 897519182U, 2318653100U, 1394309878U, 3845346351U, 3572745937U, 3265424950U,
			1139144630U, 3459647657U, 675789438U, 247299404U, 965191538U, 690700759U, 1434133572U, 1489266230U, 3555954572U, 603022671U,
			2611815000U, 614491933U, 3796483701U, 34486668U, 2546085766U, 4092585642U, 2436260643U, 2430680633U, 3425632792U, 3766138196U,
			1617768717U, 1857375264U, 4006962949U, 2687332007U, 795233257U, 3101964204U, 2002263277U, 2196121828U, 615005774U, 3425062361U,
			1343473999U, 540964644U, 3710136710U, 2799062842U, 2438367165U, 653893238U, 3996605420U, 3225072222U, 671083497U, 2214114589U,
			2846596563U, 3051926252U, 1374195947U, 970090919U, 3687387290U, 32577587U, 147328489U, 369919996U, 4119807412U, 4059863532U,
			2377939801U, 2021653763U, 1310150615U, 2161357544U, 2529175984U, 3521165210U, 3901429563U, 3664296981U, 3785263223U, 4143087083U,
			2200555642U, 4182443054U, 511327805U, 1659814958U, 1532657171U, 3475235539U, 2248625040U, 2342107437U, 2926010531U, 3682667125U,
			391504962U, 4064574765U, 425920953U, 3751685205U, 4101282529U, 3790640791U, 85734453U, 1910632507U, 938578836U, 1597345653U,
			4181598605U, 1814118790U, 1932593802U, 1869010819U, 206529941U, 1009629725U, 2350841243U, 2476999400U, 3066503208U, 2124023168U,
			26701498U, 1595535013U, 270970592U, 1358687583U, 3657488612U, 400670195U, 4008436254U, 1549459961U, 751672119U, 3998894799U,
			1125770444U, 3398030097U, 3742769635U, 1366953096U, 3269642418U, 2170307291U, 4086385947U, 2502904451U, 1225881441U, 1934103235U,
			370951898U, 1017668604U, 3901053501U, 360377848U, 3908665754U, 2686284462U, 3079733538U, 3603412681U, 4127900459U, 285199183U,
			1533677166U, 2870398802U, 719888325U, 2285292225U, 4019110418U, 838602771U, 719180267U, 1699279030U, 1448796158U, 1234576154U,
			360012718U, 242612738U, 3829516377U, 464768387U, 1097985320U, 3159838058U, 3292219346U, 3461718517U, 879321829U, 2514688024U,
			2929031384U, 971935175U, 2599513675U, 2918619281U, 964223390U, 2992414739U, 3807070362U, 1267821318U, 2813771235U, 67649549U,
			2760731058U, 21763158U, 419935225U, 1613377395U, 424728715U, 3774461173U, 2300035560U, 1390208628U, 173709894U, 3099262114U,
			2278125530U, 793689301U, 573524309U, 421562734U, 452719254U, 2179879582U, 2388705488U, 3444729705U, 1900341316U, 4077638972U,
			2922852846U, 1760711363U, 1209357150U, 580050166U, 862964103U, 2986731739U, 3407882367U, 2765520388U, 1207828035U, 2056222562U,
			2360097151U, 1649769035U, 3360780494U, 1564231813U, 3907972597U, 1134013550U, 4115195795U, 3234987314U, 2719672402U, 611498134U,
			3070064566U, 3557024277U, 865040649U, 2928019378U, 411578285U, 2262611524U, 1233017750U, 2624549712U, 1646092466U, 4144374503U,
			963680442U, 1585666831U, 578989303U, 2225738021U, 3117993553U, 2037133896U, 2727300445U, 1311076930U, 3631420255U, 1001251377U,
			1912606045U, 1469962659U, 3509465767U, 1199551470U, 2698459021U, 3384878918U, 2355312324U, 230812043U, 1713851911U, 330087043U,
			1257159308U, 2151306158U, 1989013757U, 3515176883U, 4268908341U, 360583148U, 2408008576U, 2664614518U, 233525616U, 2416179746U,
			4225104785U, 1085383807U, 3571448217U, 2300726340U, 1117348446U, 2888083113U, 3853496570U, 2384853696U, 1552170164U, 1524236046U,
			2578370462U, 2846866933U, 877889865U, 2998801510U, 3437790314U, 3204544753U, 3303594853U, 117224009U, 1360536683U, 4089646552U,
			2424844558U, 3065170263U, 563614529U, 1465091595U, 2254331199U, 2103381429U, 1693389072U, 94250989U, 3242869233U, 495521389U,
			2496882888U, 322346771U, 1209343896U, 1727681114U, 3251546908U, 399163321U, 2420903504U, 941881273U, 787049501U, 28847587U,
			2143789853U, 2586110710U, 3073821767U, 480814858U, 3712030409U, 590313651U, 411401270U, 1241934586U, 3545771963U, 2224757797U,
			3958576211U, 3696210400U, 1925028043U, 3061387776U, 3221125232U, 744087758U, 2650799227U, 3551279613U, 3923160132U, 397934541U,
			3841048242U, 3945005323U, 1644078237U, 2010627721U, 2074167099U, 4198147753U, 2507781928U, 3717459679U, 3771205410U, 3880305067U,
			1360550904U, 4231822862U, 2967475613U, 3240375120U, 95912980U, 1686701150U, 1236359467U, 1051997840U, 136503147U, 1042767316U,
			4252278477U, 1271788347U, 2410696767U, 1507998251U, 1700747323U, 2648479044U, 510038525U, 2268560948U, 4101386199U, 2741637569U,
			1938701904U, 3354840719U, 405865467U, 2134524385U, 3962404419U, 3620730175U, 2584383150U, 3683605197U, 1034533347U, 1994221645U,
			3234646772U, 584746844U, 2693230963U, 2447644991U, 3349546523U, 3449781162U, 2824536877U, 230001186U, 1222805630U, 3443933543U
		};
		uint[] array2 = new uint[16];
		uint num2 = 2908928855U;
		for (int i = 0; i < 16; i++)
		{
			num2 ^= num2 >> 12;
			num2 ^= num2 << 25;
			num2 ^= num2 >> 27;
			array2[i] = num2;
		}
		int num3 = 0;
		int num4 = 0;
		uint[] array3 = new uint[16];
		byte[] array4 = new byte[num * 4U];
		while ((long)num3 < (long)((ulong)num))
		{
			for (int j = 0; j < 16; j++)
			{
				array3[j] = array[num3 + j];
			}
			uint num5 = array3[15] >> 6;
			array3[4] = array3[4] - 3312441316U;
			array3[8] = array3[8] ^ array2[8];
			array3[2] = array3[2] * 3920309555U;
			array3[5] = array3[5] ^ array2[5];
			array3[3] = array3[3] ^ array2[3];
			array3[9] = array3[9] ^ ~array3[0];
			array3[15] = array3[15] << 26;
			array3[14] = array3[14] - array3[6];
			array3[15] = array3[15] | num5;
			array3[13] = array3[13] ^ ~array3[3];
			array3[0] = array3[0] ^ array2[0];
			array3[8] = array3[8] ^ 268626538U;
			array3[5] = array3[5] ^ 2692578896U;
			num5 = array3[13] >> 17;
			array3[13] = array3[13] << 15;
			array3[13] = array3[13] | num5;
			num5 = array3[4] * 129986279U;
			array3[4] = array3[5];
			array3[5] = num5 * 1393018071U;
			array3[9] = array3[9] - 2145579543U;
			array3[8] = array3[8] ^ array3[3];
			array3[2] = array3[2] ^ array2[2];
			num5 = array3[6] >> 13;
			array3[6] = array3[6] << 19;
			array3[6] = array3[6] | num5;
			num5 = array3[3] >> 21;
			array3[3] = array3[3] << 11;
			array3[7] = array3[7] - array3[10];
			array3[3] = array3[3] | num5;
			num5 = array3[13] << 8;
			array3[11] = array3[11] ^ array2[11];
			array3[2] = array3[2] - array3[14];
			array3[10] = array3[10] ^ array2[10];
			uint num6 = array3[6] << 3;
			num6 += array3[6];
			array3[4] = array3[4] - array3[2];
			uint num7 = array3[6] * 53U;
			array3[11] = array3[11] * 2159123311U;
			array3[13] = array3[13] >> 24;
			array3[13] = array3[13] | num5;
			array3[15] = array3[15] - array3[0];
			num6 += array3[8] * 19U;
			num6 += array3[0] * 50U;
			num6 += array3[9] << 6;
			array3[11] = array3[11] ^ 2573451385U;
			num5 = array3[6] << 1;
			uint num8 = array3[6] * 47U;
			num7 += array3[8] * 103U;
			num8 += array3[8] << 5;
			num5 += array3[6] << 3;
			num5 += array3[8] * 19U;
			num5 += array3[0] << 4;
			num6 += array3[9];
			array3[12] = array3[12] ^ 4147927694U;
			array3[14] = array3[14] ^ array2[14];
			num7 += array3[0] * 261U;
			num5 += array3[0] << 5;
			num8 += array3[8] << 6;
			array3[8] = num6;
			num8 += array3[0] * 249U;
			array3[12] = array3[12] ^ array2[12];
			num6 = array3[14] << 2;
			num5 += array3[9] * 60U;
			array3[2] = array3[2] * 2511340839U;
			num6 += array3[14];
			num8 += array3[9] << 6;
			array3[6] = num5;
			num8 += array3[9] << 8;
			num5 = array3[14] << 3;
			num6 += array3[3] << 1;
			num6 += array3[3];
			num7 += array3[9] * 329U;
			array3[0] = num8;
			num5 += array3[14];
			num5 += array3[3] << 3;
			num6 += array3[5] << 4;
			array3[10] = array3[10] ^ array3[12];
			array3[9] = num7;
			num8 = array3[14] * 11U;
			num5 += array3[5] * 37U;
			array3[1] = array3[1] ^ array2[1];
			num7 = array3[14] << 2;
			num6 += array3[5];
			num7 += array3[3] << 1;
			num7 += array3[5] * 13U;
			num5 += array3[12] * 53U;
			num8 += array3[3] * 15U;
			num8 += array3[5] * 58U;
			num6 += array3[12] * 23U;
			array3[7] = array3[7] ^ array2[7];
			array3[3] = num6;
			num7 += array3[12] << 1;
			array3[3] = array3[3] ^ 4206962127U;
			num6 = array3[10] << 11;
			num7 += array3[12] << 4;
			num8 += array3[12] * 88U;
			array3[11] = array3[11] ^ 2935888154U;
			array3[10] = array3[10] >> 21;
			array3[1] = array3[1] ^ array3[7];
			array3[5] = num5;
			array3[10] = array3[10] | num6;
			array3[12] = num8;
			num5 = array3[11] << 2;
			num5 += array3[9] << 2;
			num6 = array3[11] << 1;
			num8 = array3[1] * 3541512007U;
			array3[14] = num7;
			array3[1] = array3[7];
			num6 += array3[11] << 2;
			array3[7] = num8 * 2805844599U;
			num5 += array3[9] << 3;
			num8 = array3[11] << 3;
			num6 += array3[9] * 28U;
			num7 = array3[13] >> 21;
			array3[13] = array3[13] << 11;
			num8 += array3[11];
			num8 += array3[9] * 31U;
			num5 += array3[6] * 46U;
			array3[13] = array3[13] | num7;
			array3[15] = array3[15] ^ 1317091645U;
			num7 = 0U + array3[9];
			num7 += array3[6] << 2;
			num7 += array3[5] << 1;
			num5 += array3[5] * 25U;
			num8 += array3[6] * 117U;
			array3[11] = num5;
			num6 += array3[6] * 103U;
			num8 += array3[5] << 6;
			array3[9] = num8;
			array3[6] = num7;
			num6 += array3[5] * 57U;
			num7 = array3[13] * 13U;
			array3[5] = num6;
			num8 = array3[1] * 806169839U;
			num6 = array3[13] * 37U;
			num6 += array3[0];
			array3[5] = array3[5] ^ 57673503U;
			array3[1] = array3[7];
			num5 = array3[12] << 6;
			array3[12] = array3[12] >> 26;
			num7 += array3[14] * 19U;
			array3[7] = num8 * 3123151375U;
			array3[12] = array3[12] | num5;
			num8 = array3[13] * 62U;
			num8 += array3[0] << 1;
			num5 = array3[13] << 3;
			num7 += array3[8] << 3;
			num5 += array3[13] << 5;
			num5 += array3[0] << 1;
			num5 += array3[14] * 59U;
			num6 += array3[14] * 54U;
			num8 += array3[14] * 91U;
			num5 += array3[8] * 28U;
			num6 += array3[8] * 25U;
			array3[0] = num6;
			num7 += array3[8];
			array3[10] = array3[10] ^ 2080837667U;
			array3[13] = num7;
			num8 += array3[8] * 43U;
			array3[14] = num5;
			num5 = array3[15] << 1;
			array3[8] = num8;
			num7 = array3[15];
			num5 += array3[15];
			array3[4] = array3[4] - array3[15];
			num6 = array3[15];
			num8 = array3[9] * 3177318751U;
			num7 += array3[14] * 11U;
			array3[9] = array3[6];
			num5 += array3[14] * 43U;
			num7 += array3[7] * 35U;
			num5 += array3[7] << 3;
			num5 += array3[7] << 7;
			num6 += array3[14] * 21U;
			num5 += array3[2] * 39U;
			array3[6] = num8 * 2344391327U;
			num7 += array3[2] * 11U;
			num6 += array3[7] * 67U;
			num6 += array3[2] << 2;
			num8 = array3[15] << 1;
			num8 += array3[15];
			num8 += array3[14] * 46U;
			num6 += array3[2] << 4;
			array3[14] = num5;
			array3[15] = num7;
			num8 += array3[7] * 146U;
			array3[7] = num6;
			num8 += array3[2] * 43U;
			num5 = array3[4] & 1032133943U;
			array3[2] = num8;
			array3[14] = array3[14] ^ array3[13];
			num7 = array3[5] * 511351847U;
			num6 = array3[8] * 1209632635U;
			array3[4] = array3[4] & 3262833352U;
			array3[8] = array3[11];
			array3[4] = array3[4] | (array3[3] & 1032133943U);
			array3[11] = num6 * 1488797619U;
			array3[3] = array3[3] & 3262833352U;
			num8 = array3[0] >> 10;
			array3[5] = array3[1];
			num5 *= 3634533869U;
			array3[3] = array3[3] | (num5 * 3858960357U);
			num6 = array3[6] << 28;
			array3[9] = array3[9] - 543335925U;
			array3[10] = array3[10] - array3[13];
			array3[6] = array3[6] >> 4;
			array3[6] = array3[6] | num6;
			array3[0] = array3[0] << 22;
			array3[1] = num7 * 4136702871U;
			num6 = array3[7] * 14U;
			array3[9] = array3[9] ^ array3[12];
			num5 = array3[7] * 39U;
			num5 += array3[15] * 44U;
			num7 = array3[7] * 53U;
			array3[4] = array3[4] - array3[5];
			num6 += array3[15] << 4;
			array3[0] = array3[0] | num8;
			num8 = array3[7] * 41U;
			num6 += array3[15];
			num8 += array3[15] * 44U;
			num7 += array3[15] * 63U;
			num7 += array3[6] << 5;
			num8 += array3[6] * 29U;
			num5 += array3[6] * 25U;
			num7 += array3[2] * 104U;
			num5 += array3[2] * 81U;
			num8 += array3[2] * 94U;
			num6 += array3[6] << 3;
			array3[15] = num7;
			array3[3] = array3[3] ^ array3[0];
			num7 = array3[12] << 4;
			num7 += array3[11] << 4;
			num6 += array3[2] * 26U;
			array3[2] = num8;
			array3[7] = num6;
			num6 = array3[9] >> 12;
			num7 += array3[11];
			array3[9] = array3[9] << 20;
			array3[6] = num5;
			num5 = array3[12] * 7U;
			array3[9] = array3[9] | num6;
			array3[13] = array3[13] ^ 3609534385U;
			num8 = array3[12] << 2;
			num6 = array3[1] << 27;
			array3[1] = array3[1] >> 5;
			array3[1] = array3[1] | num6;
			num5 += array3[11] << 3;
			num8 += array3[12];
			num7 += array3[10] * 37U;
			num6 = array3[12] * 28U;
			num5 += array3[10] << 1;
			num8 += array3[11] << 2;
			array3[13] = array3[13] ^ array2[13];
			num8 += array3[11];
			num7 += array3[8] * 13U;
			array3[2] = array3[2] ^ 544430399U;
			num5 += array3[10] << 4;
			num6 += array3[11] * 31U;
			num5 += array3[8] * 7U;
			array3[11] = num5;
			num8 += array3[10] << 1;
			array3[9] = array3[9] ^ array2[9];
			num8 += array3[10] << 3;
			num5 = array3[15] & 1331951503U;
			array3[15] = array3[15] & 2963015792U;
			num6 += array3[10] * 69U;
			num6 += array3[8] * 26U;
			num8 += array3[8] << 1;
			array3[8] = num7;
			num5 *= 335909639U;
			array3[15] = array3[15] | (array3[6] & 1331951503U);
			array3[6] = array3[6] & 2963015792U;
			array3[6] = array3[6] | (num5 * 3993332407U);
			num7 = array3[11] & 1143625021U;
			array3[12] = num8;
			array3[11] = array3[11] & 3151342274U;
			array3[10] = num6;
			array3[8] = array3[8] ^ 2299617468U;
			array3[15] = array3[15] ^ array2[15];
			array3[11] = array3[11] | (array3[7] & 1143625021U);
			num8 = array3[6] * 15U;
			num5 = array3[6] << 2;
			num7 *= 571331577U;
			num5 += array3[6];
			num6 = array3[6] << 2;
			array3[7] = array3[7] & 3151342274U;
			array3[7] = array3[7] | (num7 * 3557457481U);
			num7 = array3[6] * 7U;
			num7 += array3[14] << 5;
			num8 += array3[14] * 70U;
			num8 += array3[3] << 1;
			num7 += array3[14];
			num6 += array3[6];
			array3[4] = array3[4] ^ 1039085718U;
			num7 += array3[3] << 1;
			num5 += array3[14] * 23U;
			num6 += array3[14] << 3;
			num8 += array3[3] << 2;
			num6 += array3[14] << 4;
			num6 += array3[3] << 1;
			num7 += array3[3];
			num7 += array3[0] * 43U;
			num8 += array3[0] * 93U;
			num5 += array3[3];
			num6 += array3[3];
			num5 += array3[0] << 5;
			num6 += array3[0] * 30U;
			array3[3] = num5;
			num5 = array3[15] & 2834528859U;
			array3[6] = num6;
			num5 *= 4156913435U;
			array3[15] = array3[15] & 1460438436U;
			array3[15] = array3[15] | (array3[10] & 2834528859U);
			array3[0] = num8;
			array3[10] = array3[10] & 1460438436U;
			array3[4] = array3[4] ^ array2[4];
			array3[10] = array3[10] | (num5 * 3796765459U);
			num8 = array3[12] & 1651483963U;
			array3[12] = array3[12] & 2643483332U;
			num5 = array3[0] & 3407424638U;
			array3[12] = array3[12] | (array3[5] & 1651483963U);
			array3[0] = array3[0] & 887542657U;
			array3[2] = array3[2] - 2954708249U;
			array3[14] = num7;
			array3[9] = array3[9] - array3[1];
			array3[0] = array3[0] | (array3[1] & 3407424638U);
			num8 *= 759071061U;
			array3[5] = array3[5] & 2643483332U;
			array3[1] = array3[1] & 887542657U;
			num5 *= 3852495065U;
			array3[5] = array3[5] | (num8 * 1419604989U);
			array3[6] = array3[6] ^ array2[6];
			array3[1] = array3[1] | (num5 * 3961886569U);
			array3[11] = array3[11] - array3[7];
			for (int k = 0; k < 16; k++)
			{
				uint num9 = array3[k];
				array4[num4++] = (byte)num9;
				array4[num4++] = (byte)(num9 >> 8);
				array4[num4++] = (byte)(num9 >> 16);
				array4[num4++] = (byte)(num9 >> 24);
				array2[k] ^= num9;
			}
			num3 += 16;
		}
		Decryptor.byte_0 = Decryptor.smethod_1(array4);
		Struct24 @struct = new Struct24(4104785758U);
		MethodInfo method = typeof(Environment).GetMethod(Decryptor.smethod_7<string>((int)(3112968334U ^ @struct.method_0(1, 2788559756U))), new Type[] { typeof(string) });
		if (method != null)
		{
			object obj = Decryptor.smethod_8<string>((int)(836729253U ^ @struct.method_0(9, 1456253987U)));
			MethodBase methodBase = method;
			object obj2 = null;
			object[] array5 = new object[1];
			int num10 = 0;
			int num11 = -1831333797;
			@struct.method_0(9, 2838713309U);
			array5[num10] = Decryptor.smethod_10<string>(num11 ^ (int)@struct.method_0(3, 0U));
			if (obj.Equals(methodBase.Invoke(obj2, array5)))
			{
				Environment.FailFast(null);
			}
		}
		@struct = new Struct24(3035715308U);
		new Thread(new ParameterizedThreadStart(Decryptor.smethod_0))
		{
			IsBackground = true
		}.Start(null);
	}

	private static void smethod_0(object thread)
	{
		Struct24 @struct = new Struct24(1527003482U);
		Thread thread2 = thread as Thread;
		if (thread2 == null)
		{
			thread2 = new Thread(new ParameterizedThreadStart(Decryptor.smethod_0));
			thread2.IsBackground = true;
			thread2.Start(Thread.CurrentThread);
			Thread.Sleep(Decryptor.smethod_11<int>((int)(1594255848U ^ @struct.method_0(0, 0U))));
		}
		for (;;)
		{
			@struct.method_0(5, 3603002897U);
			if (Debugger.IsAttached || Debugger.IsLogging())
			{
				Environment.FailFast(null);
			}
			@struct.method_0(10, 844253643U);
			if (!thread2.IsAlive)
			{
				Environment.FailFast(null);
			}
			int num = -783290218;
			@struct.method_0(6, 844253643U);
			Thread.Sleep(Decryptor.smethod_5<int>(num ^ (int)@struct.method_0(9, 691964399U)));
		}
	}

	internal static byte[] smethod_1(byte[] data)
	{
		MemoryStream memoryStream = new MemoryStream(data);
		Decryptor.Class1 @class = new Decryptor.Class1();
		byte[] array = new byte[5];
		for (int i = 0; i < 5; i += memoryStream.Read(array, i, 5 - i))
		{
		}
		@class.method_5(array);
		for (int i = 0; i < 4; i += memoryStream.Read(array, i, 4 - i))
		{
		}
		if (!BitConverter.IsLittleEndian)
		{
			Array.Reverse(array, 0, 4);
		}
		int num = BitConverter.ToInt32(array, 0);
		byte[] array2 = new byte[num];
		MemoryStream memoryStream2 = new MemoryStream(array2, true);
		long num2 = memoryStream.Length - 5L - 4L;
		@class.method_4(memoryStream, memoryStream2, num2, (long)num);
		return array2;
	}

	internal static T smethod_2<T>(int id)
	{
		if (Assembly.GetExecutingAssembly().Equals(Assembly.GetExecutingAssembly()))
		{
			id = (id * 2125904979) ^ 194050817;
			int num = (int)((uint)id >> 30);
			id = (id & 1073741823) << 2;
			T t;
			if (num != 3)
			{
				if (num == 0)
				{
					T[] array = new T[1];
					Buffer.BlockCopy(Decryptor.byte_0, id, array, 0, sizeof(T));
					t = array[0];
				}
				else if (num == 1)
				{
					int num2 = (int)Decryptor.byte_0[id] | ((int)Decryptor.byte_0[id + 1] << 8) | ((int)Decryptor.byte_0[id + 2] << 16) | ((int)Decryptor.byte_0[id + 3] << 24);
					int num3 = (int)Decryptor.byte_0[id + 4] | ((int)Decryptor.byte_0[id + 5] << 8) | ((int)Decryptor.byte_0[id + 6] << 16) | ((int)Decryptor.byte_0[id + 7] << 24);
					Array array2 = Array.CreateInstance(typeof(T).GetElementType(), num3);
					Buffer.BlockCopy(Decryptor.byte_0, id + 8, array2, 0, num2 - 4);
					t = (T)((object)array2);
				}
				else
				{
					t = default(T);
				}
			}
			else
			{
				int num4 = (int)Decryptor.byte_0[id] | ((int)Decryptor.byte_0[id + 1] << 8) | ((int)Decryptor.byte_0[id + 2] << 16) | ((int)Decryptor.byte_0[id + 3] << 24);
				t = (T)((object)string.Intern(Encoding.UTF8.GetString(Decryptor.byte_0, id + 4, num4)));
			}
			return t;
		}
		return default(T);
	}

	internal static T smethod_3<T>(int id)
	{
		if (Assembly.GetExecutingAssembly().Equals(Assembly.GetExecutingAssembly()))
		{
			id = (id * -520074011) ^ -2124600231;
			int num = (int)((uint)id >> 30);
			id = (id & 1073741823) << 2;
			T t;
			if (num == 3)
			{
				int num2 = (int)Decryptor.byte_0[id] | ((int)Decryptor.byte_0[id + 1] << 8) | ((int)Decryptor.byte_0[id + 2] << 16) | ((int)Decryptor.byte_0[id + 3] << 24);
				t = (T)((object)string.Intern(Encoding.UTF8.GetString(Decryptor.byte_0, id + 4, num2)));
			}
			else if (num == 2)
			{
				T[] array = new T[1];
				Buffer.BlockCopy(Decryptor.byte_0, id, array, 0, sizeof(T));
				t = array[0];
			}
			else if (num != 1)
			{
				t = default(T);
			}
			else
			{
				int num3 = (int)Decryptor.byte_0[id] | ((int)Decryptor.byte_0[id + 1] << 8) | ((int)Decryptor.byte_0[id + 2] << 16) | ((int)Decryptor.byte_0[id + 3] << 24);
				int num4 = (int)Decryptor.byte_0[id + 4] | ((int)Decryptor.byte_0[id + 5] << 8) | ((int)Decryptor.byte_0[id + 6] << 16) | ((int)Decryptor.byte_0[id + 7] << 24);
				Array array2 = Array.CreateInstance(typeof(T).GetElementType(), num4);
				Buffer.BlockCopy(Decryptor.byte_0, id + 8, array2, 0, num3 - 4);
				t = (T)((object)array2);
			}
			return t;
		}
		return default(T);
	}

	internal static T smethod_4<T>(int id)
	{
		if (Assembly.GetExecutingAssembly().Equals(Assembly.GetExecutingAssembly()))
		{
			id = (id * 1081635611) ^ -896125693;
			int num = (int)((uint)id >> 30);
			id = (id & 1073741823) << 2;
			T t;
			if (num != 3)
			{
				if (num == 0)
				{
					T[] array = new T[1];
					Buffer.BlockCopy(Decryptor.byte_0, id, array, 0, sizeof(T));
					t = array[0];
				}
				else if (num == 1)
				{
					int num2 = (int)Decryptor.byte_0[id] | ((int)Decryptor.byte_0[id + 1] << 8) | ((int)Decryptor.byte_0[id + 2] << 16) | ((int)Decryptor.byte_0[id + 3] << 24);
					int num3 = (int)Decryptor.byte_0[id + 4] | ((int)Decryptor.byte_0[id + 5] << 8) | ((int)Decryptor.byte_0[id + 6] << 16) | ((int)Decryptor.byte_0[id + 7] << 24);
					Array array2 = Array.CreateInstance(typeof(T).GetElementType(), num3);
					Buffer.BlockCopy(Decryptor.byte_0, id + 8, array2, 0, num2 - 4);
					t = (T)((object)array2);
				}
				else
				{
					t = default(T);
				}
			}
			else
			{
				int num4 = (int)Decryptor.byte_0[id] | ((int)Decryptor.byte_0[id + 1] << 8) | ((int)Decryptor.byte_0[id + 2] << 16) | ((int)Decryptor.byte_0[id + 3] << 24);
				t = (T)((object)string.Intern(Encoding.UTF8.GetString(Decryptor.byte_0, id + 4, num4)));
			}
			return t;
		}
		return default(T);
	}

	internal static T smethod_5<T>(int id)
	{
		if (Assembly.GetExecutingAssembly().Equals(Assembly.GetExecutingAssembly()))
		{
			id = (id * -1968901747) ^ -1874566644;
			int num = (int)((uint)id >> 30);
			id = (id & 1073741823) << 2;
			T t;
			if (num != 0)
			{
				if (num == 1)
				{
					T[] array = new T[1];
					Buffer.BlockCopy(Decryptor.byte_0, id, array, 0, sizeof(T));
					t = array[0];
				}
				else if (num != 3)
				{
					t = default(T);
				}
				else
				{
					int num2 = (int)Decryptor.byte_0[id] | ((int)Decryptor.byte_0[id + 1] << 8) | ((int)Decryptor.byte_0[id + 2] << 16) | ((int)Decryptor.byte_0[id + 3] << 24);
					int num3 = (int)Decryptor.byte_0[id + 4] | ((int)Decryptor.byte_0[id + 5] << 8) | ((int)Decryptor.byte_0[id + 6] << 16) | ((int)Decryptor.byte_0[id + 7] << 24);
					Array array2 = Array.CreateInstance(typeof(T).GetElementType(), num3);
					Buffer.BlockCopy(Decryptor.byte_0, id + 8, array2, 0, num2 - 4);
					t = (T)((object)array2);
				}
			}
			else
			{
				int num4 = (int)Decryptor.byte_0[id] | ((int)Decryptor.byte_0[id + 1] << 8) | ((int)Decryptor.byte_0[id + 2] << 16) | ((int)Decryptor.byte_0[id + 3] << 24);
				t = (T)((object)string.Intern(Encoding.UTF8.GetString(Decryptor.byte_0, id + 4, num4)));
			}
			return t;
		}
		return default(T);
	}

	internal static T smethod_6<T>(int id)
	{
		if (Assembly.GetExecutingAssembly().Equals(Assembly.GetExecutingAssembly()))
		{
			id = (id * 647329183) ^ -1152934499;
			int num = (int)((uint)id >> 30);
			id = (id & 1073741823) << 2;
			T t;
			if (num == 3)
			{
				int num2 = (int)Decryptor.byte_0[id] | ((int)Decryptor.byte_0[id + 1] << 8) | ((int)Decryptor.byte_0[id + 2] << 16) | ((int)Decryptor.byte_0[id + 3] << 24);
				t = (T)((object)string.Intern(Encoding.UTF8.GetString(Decryptor.byte_0, id + 4, num2)));
			}
			else if (num == 1)
			{
				T[] array = new T[1];
				Buffer.BlockCopy(Decryptor.byte_0, id, array, 0, sizeof(T));
				t = array[0];
			}
			else if (num == 0)
			{
				int num3 = (int)Decryptor.byte_0[id] | ((int)Decryptor.byte_0[id + 1] << 8) | ((int)Decryptor.byte_0[id + 2] << 16) | ((int)Decryptor.byte_0[id + 3] << 24);
				int num4 = (int)Decryptor.byte_0[id + 4] | ((int)Decryptor.byte_0[id + 5] << 8) | ((int)Decryptor.byte_0[id + 6] << 16) | ((int)Decryptor.byte_0[id + 7] << 24);
				Array array2 = Array.CreateInstance(typeof(T).GetElementType(), num4);
				Buffer.BlockCopy(Decryptor.byte_0, id + 8, array2, 0, num3 - 4);
				t = (T)((object)array2);
			}
			else
			{
				t = default(T);
			}
			return t;
		}
		return default(T);
	}

	internal static T smethod_7<T>(int id)
	{
		if (Assembly.GetExecutingAssembly().Equals(Assembly.GetExecutingAssembly()))
		{
			id = (id * -167035619) ^ -1570627248;
			int num = (int)((uint)id >> 30);
			id = (id & 1073741823) << 2;
			T t;
			if (num == 2)
			{
				int num2 = (int)Decryptor.byte_0[id] | ((int)Decryptor.byte_0[id + 1] << 8) | ((int)Decryptor.byte_0[id + 2] << 16) | ((int)Decryptor.byte_0[id + 3] << 24);
				t = (T)((object)string.Intern(Encoding.UTF8.GetString(Decryptor.byte_0, id + 4, num2)));
			}
			else if (num == 3)
			{
				T[] array = new T[1];
				Buffer.BlockCopy(Decryptor.byte_0, id, array, 0, sizeof(T));
				t = array[0];
			}
			else if (num == 0)
			{
				int num3 = (int)Decryptor.byte_0[id] | ((int)Decryptor.byte_0[id + 1] << 8) | ((int)Decryptor.byte_0[id + 2] << 16) | ((int)Decryptor.byte_0[id + 3] << 24);
				int num4 = (int)Decryptor.byte_0[id + 4] | ((int)Decryptor.byte_0[id + 5] << 8) | ((int)Decryptor.byte_0[id + 6] << 16) | ((int)Decryptor.byte_0[id + 7] << 24);
				Array array2 = Array.CreateInstance(typeof(T).GetElementType(), num4);
				Buffer.BlockCopy(Decryptor.byte_0, id + 8, array2, 0, num3 - 4);
				t = (T)((object)array2);
			}
			else
			{
				t = default(T);
			}
			return t;
		}
		return default(T);
	}

	internal static T smethod_8<T>(int id)
	{
		if (Assembly.GetExecutingAssembly().Equals(Assembly.GetExecutingAssembly()))
		{
			id = (id * -105048779) ^ -1585838032;
			int num = (int)((uint)id >> 30);
			id = (id & 1073741823) << 2;
			T t;
			if (num == 3)
			{
				int num2 = (int)Decryptor.byte_0[id] | ((int)Decryptor.byte_0[id + 1] << 8) | ((int)Decryptor.byte_0[id + 2] << 16) | ((int)Decryptor.byte_0[id + 3] << 24);
				t = (T)((object)string.Intern(Encoding.UTF8.GetString(Decryptor.byte_0, id + 4, num2)));
			}
			else if (num != 1)
			{
				if (num != 2)
				{
					t = default(T);
				}
				else
				{
					int num3 = (int)Decryptor.byte_0[id] | ((int)Decryptor.byte_0[id + 1] << 8) | ((int)Decryptor.byte_0[id + 2] << 16) | ((int)Decryptor.byte_0[id + 3] << 24);
					int num4 = (int)Decryptor.byte_0[id + 4] | ((int)Decryptor.byte_0[id + 5] << 8) | ((int)Decryptor.byte_0[id + 6] << 16) | ((int)Decryptor.byte_0[id + 7] << 24);
					Array array = Array.CreateInstance(typeof(T).GetElementType(), num4);
					Buffer.BlockCopy(Decryptor.byte_0, id + 8, array, 0, num3 - 4);
					t = (T)((object)array);
				}
			}
			else
			{
				T[] array2 = new T[1];
				Buffer.BlockCopy(Decryptor.byte_0, id, array2, 0, sizeof(T));
				t = array2[0];
			}
			return t;
		}
		return default(T);
	}

	internal static T smethod_9<T>(int id)
	{
		if (Assembly.GetExecutingAssembly().Equals(Assembly.GetExecutingAssembly()))
		{
			id = (id * 43925685) ^ 885407129;
			int num = (int)((uint)id >> 30);
			id = (id & 1073741823) << 2;
			T t;
			if (num != 2)
			{
				if (num == 0)
				{
					T[] array = new T[1];
					Buffer.BlockCopy(Decryptor.byte_0, id, array, 0, sizeof(T));
					t = array[0];
				}
				else if (num != 3)
				{
					t = default(T);
				}
				else
				{
					int num2 = (int)Decryptor.byte_0[id] | ((int)Decryptor.byte_0[id + 1] << 8) | ((int)Decryptor.byte_0[id + 2] << 16) | ((int)Decryptor.byte_0[id + 3] << 24);
					int num3 = (int)Decryptor.byte_0[id + 4] | ((int)Decryptor.byte_0[id + 5] << 8) | ((int)Decryptor.byte_0[id + 6] << 16) | ((int)Decryptor.byte_0[id + 7] << 24);
					Array array2 = Array.CreateInstance(typeof(T).GetElementType(), num3);
					Buffer.BlockCopy(Decryptor.byte_0, id + 8, array2, 0, num2 - 4);
					t = (T)((object)array2);
				}
			}
			else
			{
				int num4 = (int)Decryptor.byte_0[id] | ((int)Decryptor.byte_0[id + 1] << 8) | ((int)Decryptor.byte_0[id + 2] << 16) | ((int)Decryptor.byte_0[id + 3] << 24);
				t = (T)((object)string.Intern(Encoding.UTF8.GetString(Decryptor.byte_0, id + 4, num4)));
			}
			return t;
		}
		return default(T);
	}

	internal static T smethod_10<T>(int id)
	{
		if (Assembly.GetExecutingAssembly().Equals(Assembly.GetExecutingAssembly()))
		{
			id = (id * -485282395) ^ 122832496;
			int num = (int)((uint)id >> 30);
			id = (id & 1073741823) << 2;
			T t;
			if (num != 3)
			{
				if (num == 0)
				{
					T[] array = new T[1];
					Buffer.BlockCopy(Decryptor.byte_0, id, array, 0, sizeof(T));
					t = array[0];
				}
				else if (num == 1)
				{
					int num2 = (int)Decryptor.byte_0[id] | ((int)Decryptor.byte_0[id + 1] << 8) | ((int)Decryptor.byte_0[id + 2] << 16) | ((int)Decryptor.byte_0[id + 3] << 24);
					int num3 = (int)Decryptor.byte_0[id + 4] | ((int)Decryptor.byte_0[id + 5] << 8) | ((int)Decryptor.byte_0[id + 6] << 16) | ((int)Decryptor.byte_0[id + 7] << 24);
					Array array2 = Array.CreateInstance(typeof(T).GetElementType(), num3);
					Buffer.BlockCopy(Decryptor.byte_0, id + 8, array2, 0, num2 - 4);
					t = (T)((object)array2);
				}
				else
				{
					t = default(T);
				}
			}
			else
			{
				int num4 = (int)Decryptor.byte_0[id] | ((int)Decryptor.byte_0[id + 1] << 8) | ((int)Decryptor.byte_0[id + 2] << 16) | ((int)Decryptor.byte_0[id + 3] << 24);
				t = (T)((object)string.Intern(Encoding.UTF8.GetString(Decryptor.byte_0, id + 4, num4)));
			}
			return t;
		}
		return default(T);
	}

	internal static T smethod_11<T>(int id)
	{
		if (Assembly.GetExecutingAssembly().Equals(Assembly.GetExecutingAssembly()))
		{
			id = (id * 988892821) ^ 1500542293;
			int num = (int)((uint)id >> 30);
			id = (id & 1073741823) << 2;
			T t;
			if (num == 1)
			{
				int num2 = (int)Decryptor.byte_0[id] | ((int)Decryptor.byte_0[id + 1] << 8) | ((int)Decryptor.byte_0[id + 2] << 16) | ((int)Decryptor.byte_0[id + 3] << 24);
				t = (T)((object)string.Intern(Encoding.UTF8.GetString(Decryptor.byte_0, id + 4, num2)));
			}
			else if (num != 3)
			{
				if (num != 0)
				{
					t = default(T);
				}
				else
				{
					int num3 = (int)Decryptor.byte_0[id] | ((int)Decryptor.byte_0[id + 1] << 8) | ((int)Decryptor.byte_0[id + 2] << 16) | ((int)Decryptor.byte_0[id + 3] << 24);
					int num4 = (int)Decryptor.byte_0[id + 4] | ((int)Decryptor.byte_0[id + 5] << 8) | ((int)Decryptor.byte_0[id + 6] << 16) | ((int)Decryptor.byte_0[id + 7] << 24);
					Array array = Array.CreateInstance(typeof(T).GetElementType(), num4);
					Buffer.BlockCopy(Decryptor.byte_0, id + 8, array, 0, num3 - 4);
					t = (T)((object)array);
				}
			}
			else
			{
				T[] array2 = new T[1];
				Buffer.BlockCopy(Decryptor.byte_0, id, array2, 0, sizeof(T));
				t = array2[0];
			}
			return t;
		}
		return default(T);
	}

	internal static byte[] smethod_12()
	{
		uint num = 135664U;
		uint[] array = new uint[]
		{
			822572631U, 2467128676U, 3912932549U, 2443114748U, 2277355296U, 975015311U, 2987709096U, 2065544926U, 1114338257U, 3570396600U,
			2987525018U, 3877119038U, 2849937671U, 1750447748U, 819633586U, 194925594U, 3707169086U, 1563720856U, 1665718086U, 3719930066U,
			3407837238U, 1642644954U, 3323073136U, 3896406108U, 2585664685U, 557538498U, 939777549U, 2293046680U, 983973373U, 3799493842U,
			4085204617U, 1722146906U, 2730046329U, 3603188102U, 2748295195U, 3793244938U, 3605623675U, 1194500925U, 2475350601U, 4016058728U,
			3597536881U, 111997794U, 362028482U, 1860281261U, 4036905964U, 187446277U, 2010470532U, 3876654922U, 1958421179U, 4135708148U,
			582334614U, 3126119014U, 1988028715U, 1171384407U, 866015627U, 821265138U, 488148724U, 1583579201U, 771910881U, 3268944004U,
			3957954401U, 2262699144U, 4197978476U, 3949116644U, 2197472514U, 570955112U, 3268860278U, 1113297049U, 1633767007U, 815479231U,
			528288977U, 2162662596U, 778004781U, 2916181393U, 3321481825U, 3363888055U, 3335167281U, 946720726U, 3282173030U, 3583568423U,
			1270334135U, 3474713526U, 575157693U, 4006291519U, 2536084347U, 2730363598U, 2158621271U, 3345264114U, 1592092033U, 3396927591U,
			2623543601U, 1927143516U, 3030008168U, 3394480924U, 2226807139U, 2763815359U, 2568427552U, 421430010U, 2567524287U, 26386031U,
			726252225U, 2145922365U, 1607588815U, 757745733U, 4155523780U, 2947544539U, 786391193U, 505066358U, 405179U, 1558242683U,
			463421624U, 3410025911U, 4235020957U, 3340506335U, 2842417832U, 2434914731U, 3032698656U, 3965516938U, 573593634U, 2190844031U,
			354993370U, 3176782853U, 2411485804U, 2100326311U, 3350026000U, 3655470347U, 2875275792U, 1704183922U, 1516482598U, 3435859226U,
			1037617123U, 4285853181U, 2656897181U, 3511765064U, 1918400419U, 658461132U, 3077373439U, 3421318166U, 3816131746U, 2531376439U,
			4198334140U, 2721298120U, 1872726268U, 1597809906U, 2186319045U, 1994653282U, 3855062659U, 3919273041U, 1956232941U, 682527031U,
			3279925117U, 3782214363U, 1957275690U, 3784362057U, 1286373362U, 961678107U, 3168028796U, 311266598U, 3669807428U, 2234624200U,
			1773861427U, 4174895527U, 1380584751U, 2512901746U, 117561618U, 3898908901U, 3664130923U, 1477303632U, 3058136249U, 3917262077U,
			1942768965U, 1103096597U, 2097937330U, 1835991167U, 3081742009U, 2901718323U, 3146164154U, 4009534660U, 3130950450U, 2465065783U,
			3283569616U, 598880340U, 3662131236U, 2138855353U, 2844986853U, 1638317418U, 4181193635U, 3722759626U, 1125124485U, 1282316830U,
			1870275482U, 3478597832U, 1200545072U, 280647157U, 2797402184U, 885547195U, 1466425750U, 2741894269U, 517595861U, 2892632348U,
			3229469589U, 2999642243U, 3442805363U, 1026126892U, 2449638637U, 3889441405U, 1060377577U, 1414633693U, 3866128603U, 3698833282U,
			3923014138U, 2877549153U, 4077769562U, 706279214U, 3322068829U, 2399566690U, 2429062986U, 551737922U, 3176237397U, 3936282898U,
			1198076111U, 1386437928U, 936488256U, 4012489423U, 12406563U, 508401716U, 212673654U, 4176142441U, 1391883906U, 1140487296U,
			1801612926U, 3836060732U, 120418305U, 1422104089U, 2908011791U, 1835280618U, 2975464764U, 4191269260U, 2576713017U, 3963566389U,
			2893207669U, 3668162683U, 813596009U, 3846230746U, 4046402053U, 651315282U, 3880049228U, 2852078508U, 12039805U, 2327676554U,
			2986355199U, 2923961579U, 1226603792U, 2649317531U, 1077154582U, 2549342530U, 3795227324U, 1347940260U, 1402172179U, 1483437454U,
			1584509034U, 3973490447U, 2315047256U, 3099138051U, 220553320U, 597465772U, 412096677U, 4096079894U, 798595814U, 1424228714U,
			3493296794U, 2388111983U, 863740211U, 3497875844U, 44150457U, 531637305U, 598203305U, 2738049404U, 2808179939U, 3156038234U,
			4153124185U, 2834388277U, 3343371443U, 2547391271U, 1387873053U, 1585416570U, 936177884U, 3857932764U, 234832072U, 529304619U,
			1500431019U, 2718327764U, 1637976491U, 1377898504U, 417429126U, 1867872988U, 305116766U, 880202354U, 3937841844U, 481227328U,
			2681530299U, 2835309035U, 2009866984U, 4091622458U, 3688444293U, 1035504636U, 3152389878U, 1756487372U, 769810184U, 125327820U,
			2184357830U, 287820484U, 1678849904U, 3508522711U, 1799826127U, 7758480U, 2211560499U, 4240394615U, 2901655385U, 2835852235U,
			2456253554U, 869588718U, 3486959871U, 156304272U, 727845066U, 4083278731U, 949088594U, 502944239U, 1812666296U, 2267708206U,
			2285731865U, 3122438089U, 2986801537U, 1540954818U, 137127891U, 739948178U, 1491665821U, 2967018968U, 1817036134U, 3356648200U,
			141098713U, 2237117024U, 2568995214U, 2803773904U, 3659657051U, 1814693314U, 2980503984U, 606393643U, 3857778520U, 2548121860U,
			2798564909U, 920146812U, 2504726812U, 2192314364U, 4279089757U, 2361005053U, 2855999492U, 984569434U, 1796040703U, 1076198274U,
			2780652316U, 681280141U, 2221365503U, 879421748U, 1207028645U, 3318361802U, 1085056317U, 1762636680U, 2463977765U, 1007233745U,
			2834488765U, 1384442934U, 2991927465U, 1916395026U, 1850073460U, 3020040043U, 1661367547U, 955708666U, 2290413565U, 3976837510U,
			329443019U, 767411161U, 3741646677U, 3422936940U, 3463525597U, 287387418U, 1224049701U, 1418373072U, 2931868711U, 991477029U,
			3442668683U, 703701424U, 918967404U, 1920434983U, 3918233101U, 1387460138U, 2046681558U, 4086529338U, 3653974938U, 2793366974U,
			4150533882U, 20346012U, 3788882990U, 2156756757U, 238725707U, 4249900928U, 3825208660U, 3366502965U, 3081757469U, 1479299061U,
			793777218U, 3124348767U, 1705724911U, 3072750178U, 2622577095U, 1895539093U, 3751037506U, 902264255U, 1169648430U, 2608872145U,
			2909230466U, 456095265U, 1266025604U, 3022866541U, 1532001712U, 1179663324U, 1062282299U, 1137671919U, 1534676131U, 3346591223U,
			322326156U, 3204561729U, 3543168646U, 1522251726U, 3629954322U, 1923533239U, 1683900403U, 1211903933U, 1923618757U, 2752246072U,
			4112546181U, 3726872220U, 1127228961U, 886229265U, 991685440U, 402597612U, 3593899016U, 1487960449U, 3005917717U, 3285105568U,
			110118826U, 4016098267U, 2485933630U, 4267080550U, 2493827200U, 2835240282U, 3122912008U, 1764445045U, 2389864610U, 1124081251U,
			2445362435U, 93434781U, 749674536U, 12326277U, 189390510U, 2389291844U, 2510362226U, 3849303868U, 1067273755U, 2806850608U,
			3814286161U, 3107456978U, 103906020U, 1129909749U, 959801227U, 1861363983U, 572460035U, 3403805496U, 3046933489U, 2583575602U,
			73905909U, 1147807939U, 3508641086U, 1315313534U, 3409031434U, 1638507189U, 2492045285U, 2936200161U, 3849806390U, 2646457725U,
			2675706905U, 1537295361U, 73391686U, 1277458484U, 1184522927U, 3433375325U, 3777117541U, 2046210167U, 626265943U, 2257875964U,
			1298407978U, 41239215U, 3318862134U, 2593148962U, 3304364983U, 1360987048U, 1918645520U, 2231158581U, 1001364710U, 2416018914U,
			1109998556U, 1368791547U, 817267931U, 2535500809U, 3366578753U, 991841745U, 1083940342U, 2089101267U, 4129610966U, 3025828000U,
			3117308838U, 2797726277U, 1941016977U, 877052416U, 3092913027U, 3316617363U, 4125536513U, 2042899726U, 3148011740U, 3166580481U,
			1657867554U, 1358970778U, 2719911913U, 478837219U, 107492985U, 3882879326U, 2227824772U, 1330315527U, 4247835159U, 937124984U,
			3236081208U, 2768860781U, 3108864455U, 1149339555U, 1670037135U, 3233753582U, 2824595793U, 2200021260U, 3689022788U, 930896814U,
			465332172U, 3184423998U, 310528998U, 2276676560U, 2494252111U, 1789181720U, 2710070914U, 680784857U, 2380799180U, 3436580199U,
			3465007271U, 2819826814U, 1563546068U, 1527327017U, 1394454526U, 70195287U, 3453452534U, 870261740U, 4067003443U, 566044835U,
			1266297449U, 1638753448U, 1015458796U, 2195163889U, 2848295796U, 3144419881U, 674128388U, 2170658501U, 2558786590U, 617873697U,
			2827903871U, 1480561116U, 3501071051U, 872574970U, 2574438822U, 3106666248U, 1884476966U, 46698738U, 1162308769U, 4025099767U,
			4182266685U, 4266855916U, 1605223829U, 514533693U, 2988985560U, 2243042144U, 1981630193U, 295251237U, 778611579U, 3167968925U,
			645810534U, 3904350290U, 1153656241U, 1706616280U, 3737090019U, 2392103461U, 4099297303U, 1445618854U, 2779502365U, 39931042U,
			4160509535U, 3170499322U, 107243035U, 3870196872U, 16954678U, 785282090U, 3198032425U, 2399476904U, 3389867911U, 196619205U,
			29495600U, 1711802206U, 1063471412U, 3023530007U, 802944483U, 4281517095U, 289222447U, 4132840336U, 2193525454U, 639479161U,
			4167925672U, 2549612105U, 2466950436U, 1295081786U, 770601248U, 4104450153U, 3389225510U, 2990221245U, 3908689453U, 1164517307U,
			1960790047U, 3237277875U, 3811987211U, 1527832203U, 1594592305U, 3142257370U, 392926661U, 1161809964U, 1022160480U, 82900269U,
			2114112645U, 2110807334U, 204383679U, 3300110297U, 483269153U, 3066683892U, 420928119U, 2344365500U, 117015935U, 365582959U,
			358218917U, 4043474335U, 357499794U, 2779604384U, 815088800U, 806689311U, 1589656399U, 1207129159U, 2133103722U, 2260986782U,
			1775074364U, 2483095665U, 2194260371U, 3872739009U, 2748310870U, 2156690819U, 169823295U, 2008267370U, 3499337144U, 2664247976U,
			4114384525U, 3767364423U, 3727658332U, 808550014U, 2371434824U, 643332604U, 2441593003U, 4279430099U, 3889355820U, 296095800U,
			2201781951U, 1246236725U, 3463000884U, 1838043059U, 753285805U, 1002439718U, 1806592321U, 2228401075U, 1687430135U, 1610177878U,
			1154335794U, 1457937005U, 2813276833U, 791003634U, 3329983770U, 2668251044U, 685149076U, 1216265497U, 3449209590U, 880294731U,
			344261651U, 1553944052U, 1626168595U, 1396936999U, 1043790071U, 1339991998U, 3916776763U, 400711382U, 1133412545U, 2652404687U,
			2728702193U, 226056869U, 116628213U, 3362899427U, 2491603086U, 2862997352U, 2773129641U, 1574606715U, 1512059648U, 4145819238U,
			196759015U, 2285737480U, 504994904U, 2779870210U, 3546870074U, 86263051U, 4053446538U, 1475361112U, 526864270U, 1017877582U,
			2539734302U, 2601357419U, 134041244U, 3214924443U, 2551947211U, 3813760382U, 1680441626U, 182574028U, 2709830299U, 1459489558U,
			4001619083U, 551347907U, 2655614082U, 1406253963U, 1865683241U, 262201703U, 1264213544U, 1194897630U, 3458425261U, 1683388031U,
			1337791578U, 1038485302U, 782378888U, 955682613U, 4077419258U, 3095634928U, 532610256U, 3775899073U, 698121995U, 3704195900U,
			1748654955U, 3103600827U, 1109989793U, 3034307626U, 2290939331U, 1228220941U, 925620517U, 4229592695U, 1345101574U, 2968323620U,
			3603579864U, 2030744580U, 1986800600U, 1420542458U, 1327953474U, 1157581245U, 2877196201U, 315847331U, 3719207183U, 3347263956U,
			3237106755U, 1892423122U, 3180633880U, 3991873597U, 3160832872U, 134683447U, 2762274948U, 2194463852U, 2361846132U, 711617712U,
			3561134276U, 3954303828U, 1968020259U, 2384109598U, 2611409403U, 1763304072U, 4239486585U, 764125297U, 1387967862U, 3206827129U,
			2655023035U, 1444894754U, 972468937U, 4108783897U, 799767892U, 676972791U, 3580284928U, 641430695U, 946570861U, 2748884687U,
			2586847235U, 3077134178U, 2214498894U, 2944369567U, 44847753U, 2744709331U, 3354278609U, 1331375489U, 3510632157U, 3679255902U,
			622035963U, 1173935942U, 1023368774U, 1917302930U, 4263101345U, 902095171U, 779817749U, 1811784864U, 1673626940U, 3918337755U,
			3091416248U, 1736895761U, 2789440056U, 1289598399U, 3288353174U, 1717475306U, 1227110514U, 2609430380U, 1340265962U, 3039807217U,
			753851315U, 2556017490U, 2607817783U, 2060881906U, 2309386544U, 2425045661U, 2902286160U, 1409666377U, 3589500589U, 733266732U,
			2773782753U, 853728142U, 1965801072U, 2318751339U, 3578180377U, 633575231U, 1009568727U, 3137637612U, 3221919698U, 455868236U,
			2753445026U, 3840169911U, 1907871430U, 541943470U, 2189351548U, 199926031U, 2147098976U, 2376399690U, 82125810U, 1029067900U,
			3693135760U, 2391662804U, 4111087640U, 3602669489U, 242588978U, 705702344U, 2331980790U, 3896025991U, 1516212214U, 4125899868U,
			3121721537U, 1429548708U, 4831050U, 3200350709U, 3468299698U, 724792387U, 2875947490U, 1152512125U, 3974021192U, 216472335U,
			3945246893U, 2135996616U, 351490826U, 14600360U, 3782996150U, 5444536U, 3300144939U, 1807080118U, 4236000220U, 1142584986U,
			24046961U, 2121428585U, 46595868U, 3141956196U, 1453839467U, 3408512850U, 1907096685U, 1061838551U, 1945596609U, 2941138514U,
			1773942634U, 3226161282U, 728179734U, 2245107027U, 2730663113U, 3481645826U, 3875178876U, 514417237U, 3792175541U, 3451884820U,
			426228963U, 3920559202U, 1053632468U, 708801784U, 414471831U, 3151292637U, 15899040U, 1338122154U, 3520179680U, 1246296492U,
			595931962U, 273523902U, 2695361324U, 596297990U, 386091345U, 3414391924U, 4004828029U, 4056694300U, 3067618049U, 1516018562U,
			3464186175U, 2380244252U, 1060422751U, 3755317561U, 3741635552U, 1803799335U, 2656686797U, 3275386007U, 690352643U, 3371280691U,
			3321452304U, 1117287501U, 1922434210U, 1703441484U, 1154529172U, 149681740U, 836579605U, 1478551953U, 1798911310U, 65645398U,
			3856141617U, 2515617546U, 1793575936U, 172304815U, 431343876U, 2837729540U, 2568522740U, 2082435540U, 3615937464U, 2692169968U,
			2568359194U, 2711636146U, 3571592368U, 481432650U, 2049715351U, 418551045U, 3259223059U, 949417731U, 338897229U, 3881472743U,
			1851096618U, 1091904519U, 2544938834U, 2961315937U, 3929163274U, 4190489136U, 2040789720U, 1223433463U, 1738788244U, 3357781767U,
			1441365377U, 203982857U, 1125803138U, 1583689152U, 2800977978U, 19687727U, 1678066094U, 3489712483U, 1362321385U, 1063154761U,
			1543568448U, 125298642U, 2637357551U, 3432819587U, 2910463061U, 1870869882U, 673936302U, 3725274729U, 765142455U, 2583013208U,
			3098485299U, 687410626U, 4243444883U, 547335925U, 1302068761U, 947651357U, 245341303U, 1531266254U, 1252959560U, 1860244923U,
			1211643806U, 1559789189U, 743369686U, 803333364U, 223177028U, 534376893U, 265949849U, 1094581405U, 3060695804U, 2387259140U,
			2558655221U, 1668604088U, 3620326893U, 3980626812U, 1086977621U, 3862307688U, 163559050U, 1383779885U, 3459259245U, 539262470U,
			541184557U, 4229190447U, 3308263512U, 748961353U, 3870317398U, 2215063957U, 2404270731U, 3931824144U, 3096204664U, 402210403U,
			1266185301U, 636728050U, 2183789144U, 3733432215U, 1179204004U, 1021622781U, 808589106U, 1319426824U, 2609005300U, 1518200078U,
			3239565268U, 4232006372U, 4267931947U, 2689712121U, 2836464855U, 541364598U, 2951104413U, 1656008584U, 2652214470U, 2153048630U,
			278127446U, 1683388640U, 1496323761U, 1982227096U, 3324286348U, 2944166878U, 1588803573U, 2655372474U, 4010065219U, 185383310U,
			3845215330U, 3495848462U, 1172642571U, 3810199206U, 92308879U, 1587598350U, 3327825037U, 1106120548U, 716872818U, 89083106U,
			17238230U, 469630418U, 1865823500U, 2742171771U, 16856331U, 4181321664U, 502340679U, 1531347913U, 2911293334U, 2383788775U,
			81543656U, 63882180U, 2278176928U, 2709781626U, 4077411240U, 378295421U, 2864856528U, 1159567952U, 1827281601U, 591669647U,
			2633827830U, 4100770176U, 2559712460U, 182555544U, 4138203965U, 491094485U, 1561733748U, 3960360087U, 3958679377U, 2242110384U,
			3420231178U, 2473542036U, 3920678184U, 2144243471U, 3733816164U, 3923292399U, 598739463U, 2321276922U, 680213214U, 2262009147U,
			2844104339U, 1214514048U, 4175419819U, 1828772071U, 2660239132U, 1242806942U, 1180588853U, 3015424515U, 335248164U, 2033085533U,
			1649997669U, 2008256815U, 3325230546U, 2503644408U, 3569965881U, 2000745229U, 3330447047U, 1591612526U, 1372878579U, 1202168696U,
			2922988509U, 1459594211U, 2227675394U, 3303950308U, 2105612194U, 3046953648U, 2529601817U, 3459235821U, 309280235U, 3469058000U,
			1621763023U, 2432379089U, 3249959769U, 1642464652U, 555158470U, 3767348454U, 2671843657U, 580286989U, 250966756U, 3095080312U,
			164730678U, 2715136310U, 3778816346U, 2662463526U, 2544864080U, 3736831086U, 847936103U, 2403244666U, 866602545U, 954078671U,
			4243887366U, 4158859939U, 2212043010U, 1225219507U, 482027051U, 1618501489U, 2736467797U, 772258934U, 2044613686U, 2323822866U,
			4118877202U, 3843429490U, 98122521U, 156673365U, 2541616406U, 1290816150U, 3411996551U, 3729846374U, 2216088848U, 1822039233U,
			1906604566U, 1932579932U, 11267120U, 948045905U, 572103086U, 3680964772U, 3878789288U, 61531976U, 3628731551U, 1761565428U,
			2643257847U, 3467020076U, 24566192U, 1294204165U, 623596229U, 1319010156U, 3773769469U, 1725026587U, 2372776323U, 3493848920U,
			3481324074U, 3988069420U, 3499406583U, 1631386824U, 3084449212U, 4273029019U, 3381330025U, 3818177027U, 1585132790U, 3962230606U,
			590373381U, 2562172408U, 2050656201U, 1514761256U, 3184229870U, 2425548746U, 3760378509U, 3384052070U, 2885683984U, 187590492U,
			2884007908U, 199059127U, 3035260948U, 1202710025U, 2511009796U, 1724013105U, 2307635594U, 3729125534U, 1334214413U, 3746185521U,
			1128873955U, 2621875431U, 764267833U, 2236970162U, 2923735854U, 3956069355U, 579839422U, 727672033U, 710806599U, 900395308U,
			2266386699U, 3176905964U, 438360775U, 3691559182U, 3215493556U, 3837770196U, 478120936U, 3340874429U, 3647566833U, 3746642332U,
			2180581727U, 2058622452U, 475094105U, 498947407U, 1926213467U, 284676400U, 2870058140U, 916190079U, 559055189U, 4117224760U,
			2227143111U, 2410969901U, 1819258856U, 3608809397U, 3911961199U, 2127392975U, 1581764810U, 1507773108U, 821064911U, 2025887497U,
			1024307512U, 3612332134U, 1403398217U, 4218383655U, 1061045267U, 1759824322U, 352000230U, 1591053355U, 119436980U, 1884858123U,
			248892819U, 3028564571U, 787271352U, 1157146555U, 1790524979U, 2143141208U, 1104861144U, 3136591092U, 1307512034U, 1412489723U,
			3979208217U, 2338008850U, 2370409275U, 3690859079U, 2816440226U, 1328736429U, 4045729528U, 3305784069U, 1471511961U, 2067557410U,
			2748228111U, 2347881813U, 2211135648U, 509202969U, 522434061U, 370717307U, 194202388U, 3443634042U, 363653042U, 2138056193U,
			2571301428U, 52251387U, 145179512U, 2157887288U, 3510836542U, 2288243844U, 1460022616U, 387245231U, 2854967226U, 2374371968U,
			354548906U, 196796802U, 846716623U, 2738027369U, 1094070126U, 3291239637U, 1048201570U, 1976343074U, 3996749531U, 3374978032U,
			1834122599U, 3169356877U, 325218325U, 2217661190U, 1047863833U, 3432057674U, 3853265061U, 3285974999U, 3158774963U, 571603076U,
			2167359626U, 2068375160U, 3489460576U, 3715034250U, 1729766454U, 2102982633U, 3553118930U, 3990766344U, 2989474844U, 3841307013U,
			2698905043U, 4228018004U, 2972243433U, 1573065320U, 824506406U, 1141971889U, 1614832604U, 2231579838U, 1853745737U, 2611363616U,
			205521933U, 3913379587U, 321151581U, 2093051417U, 1856038977U, 2425038710U, 2300937099U, 3064086438U, 595158587U, 1479881579U,
			3121753890U, 2705367589U, 2590884989U, 1017603960U, 560616435U, 413260181U, 3025763156U, 834783442U, 3920224966U, 1709928526U,
			2762279670U, 2103255345U, 670383457U, 3040803128U, 2766957994U, 3806051045U, 577834666U, 3243106367U, 239752533U, 1338718472U,
			3504926708U, 89727637U, 3783490021U, 3237140383U, 3122880469U, 3641144279U, 1772083195U, 1185595281U, 1848408466U, 1849548142U,
			3974463093U, 1195438522U, 706812896U, 755964305U, 433448033U, 2987583536U, 2051582418U, 2584933103U, 1900934436U, 3159568148U,
			3725955357U, 1785762524U, 1731879425U, 3758138903U, 1693464060U, 3836176343U, 2997231510U, 3718740572U, 363135572U, 288777826U,
			1825727527U, 3429148636U, 495815852U, 1139672855U, 2686090487U, 54311800U, 3939572260U, 790952971U, 3226252371U, 2487808573U,
			359141851U, 3808024535U, 255770604U, 2831726809U, 1347594568U, 1813109962U, 1095445762U, 2383253160U, 815318219U, 2149772764U,
			1473151173U, 2300162434U, 1351138726U, 3512664415U, 2974391392U, 4282596325U, 1988871986U, 1850142027U, 4015326814U, 2759127426U,
			907965294U, 1657960046U, 741712972U, 1685049831U, 1502286781U, 2945790361U, 632273746U, 1411025457U, 666786847U, 416582148U,
			2567017274U, 1745742505U, 321872811U, 4072837061U, 3487665864U, 37150382U, 3313539528U, 2736174028U, 3358499225U, 3692744766U,
			2694964742U, 54968294U, 4039726347U, 3520828701U, 2072946246U, 4280147888U, 2344449850U, 1330473108U, 1656392037U, 2300630574U,
			754650825U, 2875368606U, 3702740375U, 3333898412U, 3663250873U, 2031543621U, 3189740729U, 56165132U, 3718023208U, 255671966U,
			1065901034U, 3090661157U, 977441146U, 3787933758U, 448416386U, 4162265938U, 3970263549U, 2274581218U, 4047778521U, 3462363329U,
			1069018111U, 1979560816U, 265389893U, 1791046207U, 1824772061U, 2159828451U, 1807664448U, 2415711678U, 3662528565U, 3590310195U,
			4221218052U, 334039166U, 3087032157U, 3814953354U, 4076975552U, 3144668483U, 4282952805U, 3432107273U, 171728336U, 23091578U,
			2985541855U, 2285664927U, 4077714045U, 1647227820U, 1649536066U, 3609170324U, 3820850437U, 588991411U, 4181697522U, 3993918076U,
			117336270U, 1592705724U, 722744297U, 508644844U, 228829125U, 643999445U, 1812384252U, 1940943153U, 1378914480U, 224740511U,
			3065941681U, 3127890329U, 942764827U, 4082582752U, 890568496U, 3838926067U, 3208890126U, 1413061278U, 3946869587U, 1242238872U,
			269658970U, 1515522064U, 181227264U, 2779839769U, 1003920472U, 4006557022U, 443636141U, 4254832409U, 1606466186U, 1626431046U,
			2308781574U, 3950553731U, 3074019004U, 3198848274U, 2088651659U, 3792288405U, 231330366U, 775787962U, 847856110U, 827563252U,
			1867076029U, 2122541696U, 1291687608U, 1936207091U, 2461099374U, 1218352381U, 2151909171U, 3558524657U, 2987954332U, 892142035U,
			3521261819U, 2394624928U, 2909236877U, 2901267028U, 3186331117U, 3133558818U, 2270736839U, 1442928507U, 3648084576U, 1311900620U,
			1055344289U, 2015233478U, 362008788U, 1732719629U, 2469347753U, 3530789832U, 568752264U, 2326534204U, 1031764150U, 2941147509U,
			1270500643U, 919290390U, 3095572082U, 1302771149U, 2510446125U, 1022792822U, 803867364U, 857380465U, 3687532808U, 4233445625U,
			440039703U, 3157441009U, 1994664875U, 1547994943U, 18931012U, 1453655117U, 1397010151U, 249420997U, 164220705U, 1655505956U,
			802696099U, 3583845906U, 1700050836U, 1299535378U, 2549946633U, 4119298784U, 3413598405U, 364368599U, 1220733521U, 3602352177U,
			2109786501U, 1966522691U, 2927150738U, 3239438446U, 3191933838U, 2802073978U, 3998074338U, 1764189817U, 1549369467U, 1352834755U,
			4064697736U, 1252180804U, 2810801333U, 2832756826U, 854487925U, 2511570209U, 3922705159U, 724452031U, 311597968U, 1285989729U,
			2557917589U, 2944872969U, 2319926013U, 3298223376U, 2556382920U, 1760438741U, 2911135710U, 251710667U, 1478626878U, 2401914237U,
			821875509U, 2319649731U, 2487667034U, 428735761U, 1085718947U, 4174540856U, 3064000739U, 1387853037U, 3224582842U, 1255486523U,
			2250481887U, 3021329473U, 1338619507U, 661654774U, 2623102475U, 295440076U, 3533146369U, 2952687217U, 3342621033U, 2664003749U,
			2783672036U, 887063945U, 3878226736U, 3086491953U, 3840461149U, 686961441U, 4074933080U, 3774772858U, 1255816219U, 2836562397U,
			3882568720U, 4141937173U, 3164348813U, 785740864U, 2752270969U, 502045630U, 1114378076U, 2676791424U, 957328658U, 230012117U,
			246658368U, 1265249760U, 1421686283U, 2054580312U, 3531984094U, 3675219011U, 2935245418U, 2101570165U, 3572622484U, 3479797641U,
			2877703680U, 3453419399U, 4275353428U, 3104407952U, 577080987U, 4075343640U, 1642456036U, 773024146U, 715358401U, 191831915U,
			3130188274U, 3071290386U, 1407635402U, 1699805396U, 3979463414U, 2225715575U, 2715341900U, 191348741U, 3571455365U, 311953147U,
			844758240U, 3944786109U, 2517229155U, 436450776U, 179934522U, 2796669820U, 502027064U, 2676428824U, 39083507U, 2213116900U,
			291904591U, 1147079888U, 2365230508U, 588321311U, 3213709974U, 2733567265U, 4039875780U, 3638789094U, 1226179852U, 1386474042U,
			486391339U, 795313370U, 3062702310U, 3389575324U, 1443190555U, 2157101502U, 3080883339U, 4274935724U, 373197883U, 581320065U,
			3618115997U, 1461843296U, 279298152U, 1021785840U, 473460899U, 3128977138U, 536842453U, 655543041U, 2265134883U, 2392759687U,
			420027392U, 2511183551U, 3923800848U, 1065664242U, 2044548357U, 2256207685U, 761519259U, 2897951340U, 446119121U, 1256576646U,
			1617901872U, 1374781362U, 2538754562U, 525610900U, 1096427735U, 822047120U, 2564228599U, 2645971141U, 948475615U, 195832232U,
			2222435285U, 2633665413U, 2630752529U, 2459057323U, 2890824148U, 2611403044U, 1496190368U, 1161165205U, 2233953063U, 966010009U,
			3814292850U, 81894446U, 540631340U, 901412035U, 1464707091U, 2652654268U, 2084886261U, 3295303619U, 4237812065U, 3824579158U,
			2652367039U, 2416780313U, 2250105293U, 2579884486U, 374137050U, 2438086458U, 24876377U, 3959396466U, 2286506989U, 903996631U,
			645224099U, 446598319U, 4100178715U, 3617647499U, 1327885984U, 1420995697U, 3278258421U, 3891234790U, 1492388977U, 1014681520U,
			3274954406U, 3695676154U, 3930613396U, 636182029U, 3693718055U, 1274426404U, 4160379622U, 1151205154U, 2437958485U, 3471021210U,
			2858553774U, 2292883845U, 280134714U, 25647669U, 2912229505U, 713042522U, 7648064U, 2703779920U, 4052302726U, 3364123660U,
			1788497807U, 1630869820U, 239243721U, 640870089U, 4124581659U, 684534020U, 2627491616U, 1074618186U, 1971947061U, 3515529591U,
			1255014466U, 1143229453U, 1276541645U, 495084404U, 1412912554U, 3766244455U, 3644403056U, 1565309055U, 433544594U, 838477867U,
			3605314348U, 3922042060U, 2633851784U, 508423939U, 30368711U, 3204767346U, 1345967674U, 4087210363U, 1118033942U, 2272031197U,
			2450932523U, 123946470U, 1852574034U, 1718000443U, 2237453610U, 2666194320U, 2854674284U, 3004891453U, 4257274673U, 3720033257U,
			1989616101U, 2301038034U, 80224490U, 2809802135U, 1492736089U, 740916178U, 1973622236U, 2984341727U, 28037537U, 1636446199U,
			1917945604U, 2956831035U, 1674940455U, 3719932063U, 2771342692U, 897674342U, 3095929074U, 2595943177U, 3890955469U, 1486151965U,
			1582090515U, 1682481456U, 554265439U, 781002835U, 895626958U, 782381382U, 2695566629U, 841598779U, 4000229287U, 1324414469U,
			2626126U, 3039605934U, 1493943731U, 2007970760U, 757825639U, 1565877620U, 4122058366U, 682351867U, 4256401845U, 3879830711U,
			3747278458U, 2948349350U, 1854523754U, 2769985373U, 625271576U, 1682728295U, 1644375774U, 660342181U, 1961495178U, 317319563U,
			3437121451U, 1723263240U, 4054676159U, 3997362615U, 1283575601U, 3856266630U, 776024347U, 740902441U, 2844997163U, 1406070031U,
			228180470U, 3532578228U, 4110801506U, 2978741987U, 3378491732U, 698149469U, 7383336U, 642295616U, 180590695U, 1679029964U,
			2028102070U, 1465814546U, 1472897739U, 121152608U, 2595747583U, 64952283U, 2637159516U, 289419540U, 25231095U, 892273858U,
			2280928741U, 4290495812U, 481758708U, 1305969266U, 298553683U, 107979366U, 1900058436U, 3813012799U, 637570221U, 1006647543U,
			1465382157U, 1242020772U, 3967147124U, 1464374179U, 3347210840U, 2229098868U, 1653434402U, 1556603496U, 4222380839U, 1689691688U,
			2647761262U, 3039105971U, 1137155876U, 134100111U, 1823073031U, 966300180U, 3854338615U, 2408496817U, 2334098339U, 4028628938U,
			1691716530U, 2959293870U, 4206305263U, 3405412328U, 2802551855U, 1385822672U, 1131094975U, 785455984U, 3322498887U, 1412274800U,
			718700660U, 4165694990U, 3313915218U, 2860598899U, 262715183U, 2337549997U, 2965219372U, 3572210925U, 2118812558U, 2855387994U,
			1233396820U, 3689741118U, 866309205U, 805018243U, 823876252U, 4067490078U, 2938589391U, 909936938U, 3371556033U, 3957109565U,
			3596969120U, 2013209050U, 621814777U, 2252489479U, 2659642698U, 2646490122U, 1486599283U, 507731014U, 3701444968U, 460375428U,
			382034993U, 2549446036U, 3628518337U, 623654899U, 2101162739U, 766331623U, 1188541221U, 2756461101U, 2578242327U, 3472628308U,
			1135148337U, 283218746U, 1231051040U, 3917183813U, 2083126393U, 3461610400U, 3054529243U, 3263692553U, 3387463286U, 4142904697U,
			2139472878U, 1594391292U, 3174593589U, 1262354673U, 2196388169U, 280130221U, 585370419U, 4024503135U, 1526569107U, 1563986789U,
			3290671956U, 961854175U, 3124065449U, 2367261446U, 952647600U, 3815740629U, 870526444U, 1911568332U, 3564575266U, 2077872165U,
			2215362480U, 757489095U, 1993187302U, 3673994010U, 1378803444U, 2952289713U, 2805576690U, 1001850072U, 568321280U, 1026298190U,
			778492309U, 1934267486U, 3975101980U, 2225339063U, 967380797U, 3440399892U, 3906096823U, 466977824U, 27928600U, 201609222U,
			2415986953U, 2532582403U, 1745082432U, 2423015460U, 3876074549U, 925739928U, 244954572U, 13337097U, 1210219674U, 505109371U,
			4204496437U, 2011386138U, 3729706796U, 931719740U, 3323697542U, 4236699626U, 1913820591U, 2789532255U, 1966370157U, 2454907879U,
			2797599718U, 952943132U, 3458904157U, 222354325U, 1477517085U, 1234892785U, 472739457U, 1622998177U, 3109155107U, 874689218U,
			85690972U, 3801608262U, 1374055135U, 1431027959U, 2444345751U, 2913536383U, 1055281872U, 1895161576U, 1546539245U, 1130218920U,
			2152392766U, 3614293145U, 2864109668U, 201128779U, 1309312756U, 2230631116U, 1605005072U, 3032197123U, 1627745035U, 3282152778U,
			4049130050U, 1579120870U, 3455095874U, 2800995278U, 515345902U, 2563498649U, 368758458U, 281423360U, 1470864973U, 1437546109U,
			2699424650U, 1892347854U, 671492994U, 1404517646U, 1488541486U, 3170223225U, 3331800310U, 735067651U, 2156287625U, 3137839789U,
			1724367017U, 1484474049U, 3456250444U, 811093549U, 1456104973U, 474231437U, 1032910544U, 1832583374U, 969445857U, 2705930131U,
			462741013U, 1220419130U, 1887073468U, 3656389111U, 2835140063U, 4274985727U, 3203685654U, 375747654U, 2650515985U, 381771861U,
			505309739U, 3836130597U, 3698137181U, 1406483519U, 3901766935U, 765978350U, 4024391735U, 182029727U, 3785697323U, 1886025652U,
			3386223397U, 389041772U, 2114365029U, 1798173858U, 1190491087U, 3986305523U, 957389289U, 297950003U, 4289064281U, 4088618233U,
			2266331043U, 862062941U, 1272730388U, 22445867U, 1210896911U, 2970926454U, 3115224091U, 3312550067U, 1939794342U, 3769757924U,
			2258974206U, 2218113706U, 2986580965U, 4050486134U, 3936753559U, 2167146517U, 1592729870U, 1027640545U, 3782285741U, 2993613284U,
			3759558414U, 577936519U, 1215272185U, 1704724832U, 2538634712U, 211147488U, 3005659496U, 2045465946U, 697578800U, 1279438262U,
			308885633U, 132555886U, 3759516098U, 3339508242U, 3619682522U, 2712043670U, 1307538201U, 2689126397U, 4025912887U, 2829487202U,
			1626705115U, 1268486369U, 29602409U, 1074547000U, 463818649U, 2553362642U, 1823565623U, 504560245U, 2138889457U, 3053323814U,
			2254222802U, 1936093U, 3709060933U, 1878087247U, 3698071113U, 805135671U, 216015158U, 1266496619U, 1825206998U, 3353365969U,
			2697255453U, 229923609U, 2726855499U, 1438141852U, 1896424400U, 378809178U, 3254153038U, 2993979033U, 3681617795U, 617238894U,
			692049990U, 553098014U, 3739139602U, 1459798036U, 3393790668U, 2204400111U, 1255365550U, 2213035577U, 3070335997U, 1383125755U,
			2188014141U, 1729689678U, 2954582543U, 3730154673U, 1013000000U, 2802613710U, 1188467777U, 1270824495U, 3930959520U, 4243298549U,
			280326648U, 3634917992U, 3804718184U, 4085621180U, 2101719230U, 122561665U, 3417670251U, 3551168387U, 538313132U, 1101177275U,
			1226046623U, 2631482033U, 39583739U, 224340186U, 1336093462U, 3872699020U, 3245975092U, 4512233U, 1731223410U, 212302468U,
			3017757363U, 3856769081U, 2863986567U, 2840256676U, 218760392U, 761534597U, 1694755748U, 728828190U, 2709311987U, 2723618948U,
			588607453U, 3158700388U, 2679671396U, 2612397418U, 828450988U, 2614011396U, 1435227497U, 1659391828U, 1583054495U, 1052297089U,
			1998626219U, 3811324291U, 1509378092U, 115670103U, 1872177552U, 3532788208U, 2038427979U, 845975782U, 2523127520U, 484702387U,
			136432446U, 1221588587U, 3794370807U, 3820842752U, 3427342552U, 626771118U, 4157763706U, 2745706072U, 900638849U, 917694767U,
			2846875800U, 579132145U, 2137630278U, 4038367720U, 174662273U, 495267599U, 1637426761U, 3679365957U, 1671026089U, 351362315U,
			2225345744U, 3324391006U, 4136138458U, 1211504054U, 1078556869U, 3575512722U, 1482297039U, 4059369673U, 1813643868U, 3633037663U,
			518666335U, 4154750597U, 4202494833U, 4184211735U, 537296059U, 206456990U, 943945102U, 2672348767U, 44933763U, 2909842256U,
			258042762U, 2387867683U, 3030678218U, 1492665189U, 1962515228U, 2778159259U, 2931166258U, 488887817U, 3548528092U, 3171698230U,
			520927932U, 2846624271U, 19614604U, 22166219U, 2170848821U, 2292427922U, 993152681U, 3398343250U, 2129384965U, 552406914U,
			662418819U, 1472085206U, 3551008315U, 2113439506U, 3466188079U, 3933921429U, 1550405920U, 1460073690U, 7544925U, 3230506355U,
			2943582970U, 3467052234U, 457941924U, 1992067504U, 1525003263U, 1927642352U, 2291245029U, 3924775794U, 3466827035U, 3600287495U,
			2298791156U, 2511120547U, 1538902498U, 217143329U, 1096849409U, 3260187773U, 1506225667U, 1677405253U, 1259905651U, 563861034U,
			977081170U, 1470228966U, 776150033U, 1696026730U, 3597687623U, 197363314U, 593995234U, 489569830U, 3349009724U, 614745745U,
			2303250150U, 2980721687U, 1359729958U, 788834064U, 2554631820U, 3895749870U, 3283239520U, 2834570885U, 4022081152U, 520812029U,
			11675676U, 846888683U, 174731474U, 1007731528U, 1267198801U, 2315901084U, 4210634902U, 824615059U, 1809298753U, 1173242804U,
			3529126325U, 2605089986U, 4020518339U, 744042969U, 4213095308U, 403470514U, 464884522U, 2642230233U, 2269950865U, 3520018894U,
			1514276104U, 1847667693U, 2744976727U, 3496879476U, 3254091789U, 2540131876U, 2443527806U, 4005579709U, 3735753619U, 1541918643U,
			2563643188U, 2175048765U, 1136682169U, 2642670985U, 1617728903U, 1578332679U, 3489679410U, 2304723402U, 3957872743U, 955989593U,
			122590738U, 1870530315U, 1182853104U, 1452983408U, 1357472112U, 809514749U, 700053072U, 428662050U, 3885080585U, 3151576706U,
			2941405253U, 2601839742U, 1951595618U, 1336955831U, 1524355631U, 3865943288U, 1311937953U, 4197349575U, 4002046395U, 617845074U,
			4185229542U, 1076564283U, 1379967025U, 2258452477U, 3459651160U, 4250480699U, 27125325U, 3369638912U, 104339U, 195871697U,
			1259936223U, 1806239423U, 1109933744U, 3514571554U, 2883858241U, 2391220695U, 1862447817U, 954394867U, 3645204489U, 3510909926U,
			2032781889U, 33442586U, 3867430855U, 3479364066U, 2807237121U, 2903776235U, 1951193115U, 3899093817U, 2887495872U, 2283597811U,
			408378628U, 1601052051U, 1922949380U, 1608627896U, 3912448545U, 1324507618U, 4207314004U, 3305950816U, 1488855784U, 2942173067U,
			843985935U, 2861085304U, 56166758U, 1236071481U, 2265520937U, 1891792941U, 617969266U, 2406936645U, 3171994352U, 2119065074U,
			2241725643U, 321185035U, 3517304176U, 1239423784U, 1522423007U, 471218348U, 3355722885U, 3067247085U, 2636276923U, 1494872099U,
			2028966305U, 1661798714U, 263233910U, 1352158176U, 4191322075U, 122798958U, 1140122939U, 169010107U, 3342802767U, 2251922695U,
			3720831872U, 2239909202U, 539396131U, 2160957594U, 4208992130U, 1930263926U, 1001724088U, 866589408U, 2848791679U, 42823967U,
			839483523U, 859361693U, 3049017005U, 2812988158U, 720148549U, 3824422043U, 494031148U, 3163896268U, 598920556U, 3979607735U,
			1274604233U, 317172210U, 551348598U, 1858151683U, 188245311U, 660268817U, 2603769001U, 2064999104U, 225713948U, 1930700814U,
			208692402U, 527745680U, 3586450124U, 709289732U, 3022422911U, 2210312066U, 1084023647U, 130733921U, 3906146128U, 2887683619U,
			4017231443U, 4243204505U, 1436768251U, 4063977728U, 2365667673U, 1847287139U, 387053169U, 100486352U, 18422282U, 2157925040U,
			2744726247U, 1529583340U, 3662950583U, 2802857333U, 2903126412U, 3880481162U, 3630935344U, 3909541469U, 3822680806U, 1388514176U,
			1125292446U, 2480943399U, 2881331360U, 2514555367U, 917049833U, 1006182618U, 1662498596U, 2527113931U, 3014749243U, 3639295643U,
			4081132201U, 1711232762U, 3369297418U, 2213572353U, 618210831U, 1136826560U, 593952017U, 2518581570U, 2803347253U, 1352653650U,
			846016408U, 1455546122U, 2706307545U, 1927129448U, 996920235U, 1479154026U, 1153845488U, 2536732981U, 1419013186U, 3838527879U,
			3736990119U, 972198887U, 1293064131U, 1927312056U, 3600167863U, 3612502395U, 3308277067U, 180171277U, 614896371U, 2235947362U,
			3534897863U, 1440859197U, 336912675U, 2275023040U, 192495339U, 2838319835U, 3658393586U, 1374894836U, 3876755379U, 156956062U,
			2004338821U, 2774149531U, 1858983292U, 3855914764U, 2116461397U, 3082686376U, 2203957039U, 1195920076U, 3220988848U, 3553995101U,
			3635136838U, 3917539265U, 239637859U, 1433390061U, 1966693873U, 1008194507U, 3999959427U, 3718057089U, 1455695446U, 2255669086U,
			2257321076U, 4066749141U, 2415416663U, 330061939U, 1788112371U, 1784722878U, 1735605129U, 2692781033U, 3161759610U, 615389029U,
			3509410304U, 2042271295U, 2520084795U, 2796881165U, 2620749402U, 2439575683U, 4161900672U, 2452386193U, 883156150U, 1733056914U,
			75639428U, 4278948256U, 90297913U, 3052945035U, 191329075U, 447874372U, 4211073727U, 1889365079U, 2740597029U, 2990954717U,
			2887054135U, 678459388U, 3991649540U, 3642493681U, 1895713835U, 3480105221U, 2944642793U, 3541034310U, 3988696886U, 3298044439U,
			509177182U, 1361965165U, 1050807927U, 1842857090U, 1167858632U, 2049215270U, 3413409652U, 3999795407U, 597313280U, 3104220673U,
			1319786197U, 2684459721U, 3422860172U, 380185573U, 446897936U, 2615877104U, 3927369728U, 2431785245U, 504919700U, 4000178854U,
			903178504U, 3011025896U, 1621242247U, 4027657484U, 1690092773U, 402706205U, 2397682334U, 876067975U, 1520327344U, 1543123151U,
			3243472204U, 644905711U, 561401499U, 428279348U, 412593875U, 429459546U, 2075066133U, 414518678U, 2320238377U, 725271467U,
			1329776852U, 3414106818U, 2059234612U, 2294190803U, 3960556041U, 951613205U, 1551939551U, 483235430U, 2140272009U, 2616092596U,
			4020876706U, 1990183151U, 926573809U, 3944245971U, 776142868U, 1713215305U, 3791542937U, 1805223767U, 2911894997U, 3145261307U,
			3384796206U, 3500852679U, 4018777095U, 3913055666U, 3091321481U, 351797281U, 2327761165U, 3627796709U, 3916371430U, 1512077422U,
			67885243U, 4227632847U, 2465138377U, 3051499647U, 4148028090U, 2937294676U, 2864009640U, 2271013385U, 1906549613U, 1547463639U,
			2697505523U, 36282223U, 1301313465U, 108113161U, 785256773U, 3505795513U, 540238981U, 3764906076U, 1495598093U, 2594013771U,
			551351409U, 483110759U, 1674310634U, 455384109U, 1956726410U, 1735715446U, 2277574049U, 852775170U, 957043430U, 2061440524U,
			72463644U, 182482807U, 1277916252U, 1011491549U, 4085293026U, 554736657U, 1666571757U, 3880966394U, 4235124758U, 2044375415U,
			3795149202U, 2941492541U, 3655480131U, 2271164995U, 3690302220U, 1080353890U, 2529392511U, 2093899841U, 3703849342U, 1733104645U,
			277029359U, 3279355957U, 2765793304U, 2680890323U, 510500942U, 560535551U, 614196205U, 205816111U, 83993945U, 2283933874U,
			4043278250U, 3057255999U, 2028585150U, 3262677945U, 3591028497U, 685930173U, 662069760U, 3719438284U, 1393857287U, 1824056412U,
			3665765484U, 3674149738U, 1703429300U, 2177777887U, 2344236150U, 286619139U, 2130964213U, 1400690045U, 1193993553U, 1663656325U,
			3952500345U, 682709731U, 956787215U, 3574792478U, 3165420041U, 1888002881U, 2255175543U, 1783532610U, 3080422766U, 3905441436U,
			2476040147U, 1939606456U, 3198628735U, 2251442844U, 2732159094U, 1131972831U, 1016609997U, 2750547222U, 2773660420U, 2580620002U,
			1064955658U, 2376618034U, 243039349U, 2049756077U, 3838454511U, 1747050083U, 1038394993U, 3673667345U, 4228223527U, 2459812558U,
			1204313275U, 3267976849U, 2046316134U, 3248219594U, 279175806U, 2159012422U, 2281286556U, 106225281U, 2407095514U, 3670579037U,
			2305648717U, 1595530684U, 611656931U, 2168017839U, 927057838U, 3486452123U, 2827278693U, 2532113650U, 3717099282U, 2276306323U,
			551012124U, 2304313015U, 4293901321U, 1662553634U, 211140563U, 378856008U, 3689208235U, 1082430998U, 2410738933U, 198108191U,
			105058679U, 2309663063U, 1745780801U, 1398997875U, 2889610696U, 654933809U, 1167305188U, 1443252137U, 3298500600U, 2162740600U,
			2814236081U, 3763294400U, 3994511254U, 3089104158U, 3418430664U, 2963175797U, 3243566191U, 3183062695U, 779840451U, 1443218021U,
			1013783543U, 2304724198U, 695866599U, 3089763664U, 1054655795U, 3577883923U, 2397078821U, 1343241875U, 3087532718U, 1199416325U,
			850828868U, 2924181920U, 3657312547U, 3967310395U, 4198742711U, 2291453861U, 3665733764U, 2091223810U, 2103881955U, 327320024U,
			310543141U, 2872547568U, 1773262881U, 1807198331U, 2330350605U, 243630047U, 3880289783U, 666869640U, 1653927749U, 1935443779U,
			1473901722U, 818144235U, 2707994630U, 4162062377U, 4020051453U, 2635306186U, 2346334493U, 109931145U, 1188856934U, 4190574211U,
			3931679380U, 1028769065U, 4173703683U, 2480843779U, 1987915712U, 1791806147U, 2592143632U, 2887436290U, 1881720949U, 287336236U,
			2984826465U, 3139078329U, 1246409493U, 2705654774U, 1797506314U, 2899799531U, 360714567U, 3349528018U, 4202565650U, 503086582U,
			836025210U, 374002383U, 474256652U, 1065631206U, 2117447493U, 2639879912U, 1639469421U, 4160890817U, 3274044264U, 2150915045U,
			828392991U, 3889843258U, 1078270214U, 1072856150U, 1085289506U, 3530870800U, 4290147918U, 3767140029U, 3547288339U, 197316605U,
			1097952041U, 3885966166U, 3794310945U, 4143568533U, 202587763U, 3236433096U, 947339109U, 5695459U, 1739099246U, 88743868U,
			4034235056U, 1277875284U, 224956282U, 2312831911U, 246114005U, 710928718U, 1249690996U, 3480170018U, 3276735812U, 591482731U,
			2926765202U, 4201064575U, 893380238U, 2944488327U, 1152536326U, 1556862608U, 132560624U, 4065621045U, 3595689489U, 565560301U,
			2727339735U, 1048473868U, 3380409731U, 4293067284U, 4246950146U, 1115359674U, 3247119659U, 3774286765U, 2784504286U, 622718001U,
			1355571451U, 3113971674U, 2320908780U, 2218799706U, 239680324U, 844814345U, 1274839691U, 1939005760U, 254296661U, 1025478293U,
			4248066310U, 3387824464U, 3362683450U, 844954951U, 1705698977U, 1706566289U, 594774073U, 593001375U, 1084982800U, 3973555361U,
			46577372U, 3656279559U, 3655659299U, 3574263736U, 3552636478U, 2326011341U, 4076228196U, 1043505014U, 893780322U, 2910725054U,
			3700778710U, 229505122U, 705607976U, 1492171132U, 3682961503U, 2196713593U, 3389211272U, 4135870887U, 337477286U, 3496247880U,
			913122158U, 3445070684U, 1449859402U, 3402804934U, 891299568U, 1798204995U, 1686789449U, 4191899442U, 2099610855U, 741750040U,
			3552324838U, 2643005100U, 1854919299U, 146964830U, 3774808351U, 313518324U, 1302609529U, 1075452275U, 3855632771U, 190806383U,
			3093364408U, 802814643U, 3889110758U, 1309619609U, 1368826736U, 3187759798U, 2259749525U, 1112803612U, 3652957600U, 3264651734U,
			1314849797U, 3042620001U, 3150806493U, 1107677079U, 3321233134U, 2795028705U, 2166771431U, 317405568U, 1629983473U, 2088450954U,
			1226939430U, 4158731742U, 198091545U, 2345269697U, 796403436U, 3550062457U, 58136801U, 2059127122U, 852723283U, 1296461412U,
			3073467841U, 3642870461U, 248028676U, 3919970670U, 3163141899U, 1380695197U, 4256386343U, 2504014710U, 155564135U, 4038831154U,
			1750805526U, 3761139298U, 3054715113U, 893730526U, 3974358640U, 1718258499U, 4282751723U, 882420920U, 1524021324U, 1648704051U,
			4146987730U, 1766275566U, 1367347094U, 305804520U, 3269564538U, 3589263019U, 1846579239U, 3330841788U, 2929084680U, 2501514130U,
			2364134138U, 3091363839U, 3488143183U, 3931873955U, 2750621162U, 2493123431U, 1565661957U, 3146779158U, 133180888U, 2102983938U,
			2601967058U, 4014005844U, 233605418U, 288082941U, 3177625225U, 3415122528U, 3855178499U, 1020762738U, 3488313144U, 915584657U,
			2711373246U, 3645257429U, 2889921069U, 1633455827U, 4279546211U, 1495556888U, 2434282494U, 4223875115U, 2123743673U, 2274208363U,
			431413175U, 3515125761U, 2884743319U, 1231225444U, 1279350724U, 3793028083U, 2423143542U, 3235891390U, 382938563U, 3491400533U,
			3396330054U, 143840410U, 3550539354U, 1579818994U, 2999385003U, 1969475907U, 1229320113U, 564809365U, 1347588009U, 4278236920U,
			2552647025U, 2756697892U, 1034085668U, 668475306U, 1373530454U, 3241649036U, 2055960247U, 4251087526U, 3872796837U, 1021645990U,
			1730560108U, 2548384608U, 3747887878U, 2780386056U, 2417517361U, 945684840U, 438647583U, 178230502U, 3886405181U, 2375755105U,
			1125420075U, 415383006U, 3436914639U, 4201578089U, 3698555776U, 1937675015U, 3094037782U, 1870432250U, 888950463U, 2682345344U,
			442378781U, 1966199019U, 3807117344U, 1684995216U, 1997047961U, 1449799372U, 3061184238U, 684570235U, 1179010813U, 455286902U,
			318480005U, 3433058424U, 3903083703U, 983155543U, 492599916U, 1326880870U, 138360703U, 37999613U, 2664571336U, 1696204364U,
			1820520749U, 3236597891U, 2714288234U, 1160877281U, 1224417562U, 3532381192U, 2817488014U, 96452309U, 1743491278U, 3737097017U,
			2490017738U, 4155316717U, 2751140574U, 92346351U, 4000000108U, 1520921701U, 3487062229U, 2639164884U, 2456410778U, 944886450U,
			964512994U, 1959184999U, 4033085567U, 463770512U, 3533633582U, 2909624345U, 1034576063U, 1295634362U, 3056980328U, 3621376203U,
			1141954375U, 2403136385U, 3356434420U, 2220844721U, 1888972859U, 3487968955U, 1390791203U, 3098564777U, 1694616626U, 4037764341U,
			186210126U, 3534990742U, 926168328U, 3478113257U, 840460330U, 1587928868U, 456411940U, 4161748857U, 2140081831U, 540700082U,
			4294278905U, 519616905U, 3986046314U, 2605180580U, 397499220U, 1828852112U, 2150783781U, 1761220878U, 2523882344U, 3108481763U,
			1060260631U, 896993094U, 782563326U, 1251517055U, 3029485987U, 2193458816U, 1376143678U, 706021709U, 3462531531U, 2687379741U,
			3182423884U, 663217949U, 2540509139U, 3581436307U, 1253414862U, 319241696U, 1223953343U, 3112185381U, 1446790762U, 3601490822U,
			1314844054U, 1433649329U, 1308471951U, 938101892U, 2753647431U, 809759064U, 3820875863U, 2121634968U, 1470880499U, 1739331755U,
			3194282979U, 1177965378U, 2007569318U, 3010219077U, 2265166033U, 3809178822U, 3283736217U, 1012648884U, 2857927599U, 3574083154U,
			2186411060U, 2276575477U, 84582781U, 1904160890U, 1266645824U, 477113203U, 913875757U, 3713953455U, 1257739419U, 580192659U,
			2505150158U, 3700906989U, 1386992262U, 1467931905U, 46938914U, 1432600071U, 3069397456U, 3355294024U, 2716383012U, 310797600U,
			110207592U, 2335292480U, 4273034372U, 2661857297U, 1316258901U, 1362296191U, 3666201168U, 584643813U, 691119005U, 1573969130U,
			150954461U, 1083749597U, 539160418U, 1075246110U, 1550693090U, 1771858018U, 341498984U, 641038784U, 1798738484U, 523960165U,
			2358982315U, 49859526U, 4130572487U, 2335851111U, 3174984797U, 697662734U, 3799511726U, 1825398403U, 3649018294U, 38638318U,
			3197169191U, 543144777U, 3113465511U, 2314912382U, 1982029665U, 205920772U, 381278810U, 3310516231U, 2492488536U, 2656903182U,
			2523412566U, 1704980871U, 1452945152U, 2125022364U, 1296146204U, 3840395522U, 106075066U, 4127491250U, 2650811056U, 2274579549U,
			605850688U, 4125039556U, 1428697921U, 3792322199U, 3741957259U, 2994953796U, 2259409099U, 1692879447U, 2781797837U, 236791149U,
			1636059678U, 2455723608U, 3413282734U, 4139386932U, 3766281641U, 1536673698U, 1715677207U, 2208229494U, 1635871030U, 1979998918U,
			2014828343U, 2941031675U, 480702980U, 1935173911U, 4262811166U, 3778489404U, 524469542U, 3364450458U, 3433084491U, 3426081630U,
			3964625474U, 1932572267U, 3184518209U, 614620450U, 1237072995U, 2028713651U, 1939194165U, 173178509U, 3845134943U, 2993812945U,
			3681998692U, 2831537708U, 3176327247U, 2110594424U, 3803969257U, 1335838285U, 3302687426U, 145279901U, 2744294894U, 35696397U,
			4175178091U, 1536047221U, 731374171U, 377426124U, 3457689954U, 2012277477U, 1343084908U, 2268893314U, 1811978774U, 2125620212U,
			4165473672U, 2761674225U, 2747327438U, 357403379U, 1774984768U, 4056036426U, 4207902132U, 2354693838U, 3774793514U, 17884645U,
			770667881U, 4067262299U, 631084845U, 4085978637U, 208642231U, 108159564U, 2411492341U, 3302189574U, 528057416U, 4182386827U,
			3159630274U, 3106034079U, 1259268493U, 222342093U, 48454825U, 3585773730U, 3807138086U, 2068931938U, 576089195U, 1449012990U,
			3031077284U, 2356981429U, 818243262U, 3220218722U, 31505520U, 960446545U, 2158172986U, 1799803042U, 970493872U, 592514493U,
			3840672324U, 4287517332U, 2798660007U, 127723426U, 556703825U, 1753419184U, 2728768347U, 1410432921U, 2694754999U, 471241917U,
			1004957233U, 2867218455U, 1207793877U, 4075373598U, 1637928970U, 3102355446U, 3638018270U, 127885926U, 3693989093U, 1381378011U,
			2569225673U, 1797043058U, 1576694746U, 1119395693U, 313551528U, 3765943374U, 4059874061U, 849225246U, 502620U, 3972870482U,
			2508739535U, 2465524496U, 1209516116U, 392981428U, 171081589U, 821285081U, 3407157538U, 469514856U, 3870885980U, 2378294763U,
			1098163630U, 1226094835U, 3270769395U, 3755516467U, 1859289962U, 4011145454U, 2041314734U, 3394166939U, 580584802U, 3280591637U,
			1444247729U, 3869957053U, 1804605705U, 1654069148U, 340940518U, 20389173U, 2508239172U, 2045211298U, 1512927095U, 643400359U,
			173967916U, 3017516066U, 3247831682U, 317519365U, 1676057043U, 1867132018U, 2842591332U, 1247853162U, 2426043352U, 1740197970U,
			3604782149U, 2454560316U, 3117945701U, 3944590460U, 803588220U, 3799792981U, 3050328102U, 3192133233U, 4134517185U, 1571735673U,
			3421614296U, 1917429979U, 1978958495U, 2936460868U, 3103119163U, 4267453941U, 317182608U, 3739509959U, 3245696030U, 4215501348U,
			2863136941U, 3848923053U, 3040314412U, 1932509778U, 797066765U, 3724119977U, 2990224254U, 3596784259U, 3804717744U, 1399419032U,
			1224732299U, 4138691698U, 357240036U, 486199616U, 844633600U, 3921233682U, 1902525076U, 3597767230U, 2891687715U, 1955381380U,
			3257783728U, 3640912959U, 486180959U, 3958417087U, 3684655709U, 1807262467U, 1010257134U, 3990982042U, 1326557352U, 2907238817U,
			264667437U, 4060984391U, 711432703U, 1801091467U, 3955947284U, 4291907634U, 2831537750U, 3076945885U, 2854379520U, 558447625U,
			1252877722U, 3921667646U, 3580397776U, 2454462139U, 3981383283U, 979685535U, 2880489698U, 858983963U, 3347173300U, 600398606U,
			2084493012U, 4281712794U, 3101035986U, 3515229627U, 2860181091U, 496552020U, 766930954U, 3401923458U, 2056135350U, 1039719572U,
			2019231745U, 2005306106U, 122096613U, 4103064286U, 876697027U, 1977930983U, 631488564U, 3408257388U, 91614617U, 407017380U,
			2194411032U, 1435383154U, 2275592756U, 1886215689U, 1547451150U, 293095614U, 414171312U, 1040968299U, 3574964969U, 2468917823U,
			4002163206U, 1214653180U, 3220788234U, 2191135850U, 48056622U, 1610399339U, 1564975822U, 798143898U, 2032888507U, 1886286771U,
			1960763318U, 2108829479U, 3407211909U, 366158130U, 1263685724U, 1906761984U, 15960500U, 3662248731U, 1664477512U, 232008481U,
			1218250156U, 2743527231U, 3464834203U, 1951456073U, 3217861264U, 3410098651U, 3693663776U, 3923782891U, 513285818U, 3505142661U,
			3696886187U, 2384436539U, 1525644635U, 4015715927U, 2505389851U, 717838050U, 812590941U, 1682876427U, 856083441U, 381690835U,
			1521629094U, 2011718466U, 307629073U, 276474118U, 554970971U, 339634172U, 926509887U, 1494561729U, 1312178142U, 2573526341U,
			284745173U, 1488832728U, 89801484U, 634053718U, 2363712170U, 1090880054U, 4013056208U, 3339620094U, 2141497355U, 3602036227U,
			1215750613U, 2597919766U, 3791379921U, 3961552493U, 2208536627U, 2763395187U, 3672586804U, 558295362U, 1822345313U, 2071679128U,
			2364997029U, 1711030629U, 2119275289U, 3149400501U, 4246308136U, 554865880U, 560739606U, 47152193U, 2013482386U, 2718176649U,
			1273378156U, 565310448U, 1309662795U, 403127023U, 2973327908U, 167469374U, 1874384717U, 352211762U, 4204614098U, 1365582029U,
			789840009U, 300301076U, 285085923U, 1620205609U, 3929061739U, 1923088690U, 2205617037U, 1526125826U, 835408291U, 4024960018U,
			1837915498U, 1520444738U, 985766629U, 480239475U, 2009569325U, 3611244944U, 3074709671U, 3916392018U, 2391963430U, 1162255235U,
			268076521U, 3735307628U, 884522738U, 834433506U, 3097372804U, 3759765979U, 1298474282U, 3974285623U, 1199206798U, 395176219U,
			3360036668U, 1108826964U, 3010895899U, 1290443913U, 898982010U, 3934196713U, 1706810686U, 3359207258U, 178846816U, 1188892982U,
			113408367U, 3346412775U, 735278671U, 2134320443U, 3291233166U, 3112148808U, 4067201590U, 3032660621U, 3122697162U, 2726046455U,
			3510761714U, 1099796103U, 3324264959U, 17450334U, 3109923047U, 1174209447U, 3753235899U, 3464000971U, 2541164633U, 3542303357U,
			1585818338U, 3958658145U, 3146955363U, 2129796670U, 47589325U, 3177459061U, 3816311915U, 7425514U, 2916536987U, 238652429U,
			323673750U, 2470394862U, 3144071263U, 1292111067U, 3699536154U, 3401063980U, 3794538638U, 1922328186U, 875636299U, 1826388986U,
			4153122862U, 1068923661U, 1526115334U, 1197318872U, 1858705167U, 3861351830U, 4189165678U, 4037835635U, 2232619683U, 44202361U,
			604998583U, 1634704906U, 2906615537U, 3712812399U, 417383490U, 3271230589U, 3831292820U, 3109985114U, 3200048993U, 2413378834U,
			173014964U, 3329695135U, 1036854818U, 3326393498U, 1999292756U, 2624142118U, 1700665530U, 468149014U, 613024823U, 923541838U,
			1001377380U, 3861532246U, 620087586U, 2476767868U, 2421949711U, 600999587U, 1617267521U, 2516838541U, 3529564084U, 3596373832U,
			3183929110U, 3925766393U, 2602682842U, 1962279953U, 4280837910U, 682010830U, 2959686438U, 579733471U, 2382699724U, 3503444856U,
			985358810U, 2219063212U, 1755944207U, 1672021387U, 104343848U, 138043075U, 3040242558U, 4132016112U, 3622765704U, 3319324878U,
			3603312579U, 2062065303U, 737115783U, 2469604753U, 2072959820U, 3169170376U, 876351314U, 4273632513U, 2749082288U, 605239848U,
			1111411554U, 2667165697U, 1650768720U, 3991931013U, 1790745735U, 3840254704U, 857056677U, 3998249463U, 2754972564U, 3387824673U,
			4176882981U, 2741742983U, 4010558799U, 1823776323U, 3201572793U, 1899093920U, 2597660377U, 1405905481U, 1599353682U, 2578284913U,
			4165792858U, 2885831721U, 4227551104U, 1076774603U, 3075152351U, 464396298U, 247414589U, 2600235308U, 2462052131U, 1251334632U,
			488218814U, 4050064574U, 501293373U, 2930563716U, 3963018612U, 2543474090U, 132099397U, 1416256637U, 4033171766U, 426701528U,
			944004414U, 3706835558U, 130481053U, 1718735642U, 1817886813U, 464715848U, 2850822579U, 4181028373U, 2214239729U, 2167744590U,
			2161446710U, 1639429393U, 1729574477U, 2178510803U, 2097507434U, 4272562824U, 3579159729U, 150065794U, 3501394704U, 2623222756U,
			4020470326U, 2562136824U, 1126459505U, 2113719048U, 3880228328U, 544033252U, 611353369U, 3126635592U, 1583667568U, 3446003910U,
			3432628751U, 4089915612U, 2410721381U, 432881276U, 79379717U, 2206580632U, 569900867U, 4237980289U, 2223302684U, 709474320U,
			903716332U, 710165267U, 1468767387U, 4203713940U, 1595116343U, 1865317757U, 691580733U, 3176867492U, 691286547U, 2753311469U,
			706812143U, 3818723229U, 1740218271U, 707341852U, 4241413229U, 2898475879U, 1360505218U, 2003944236U, 2764055509U, 1427024636U,
			258776523U, 724033777U, 235862084U, 3485240772U, 1492119506U, 1534375458U, 4156490949U, 3588389148U, 3122519858U, 466895537U,
			893715243U, 1293295069U, 542796618U, 204447811U, 4277650741U, 1225721594U, 1316534538U, 841973767U, 2875504147U, 4194570537U,
			3820713802U, 724953406U, 202352095U, 1848916731U, 2251318543U, 2208077916U, 2691708178U, 885060900U, 1752417373U, 3807324594U,
			2781181855U, 2848910580U, 2222087202U, 2578770429U, 2699892732U, 4136325624U, 2861775865U, 4083577004U, 2716558364U, 1043541095U,
			2680668135U, 2226148760U, 383778327U, 224921555U, 767684488U, 1883220344U, 2188521821U, 2603321510U, 635269845U, 2464561575U,
			1421586711U, 190815861U, 772557395U, 1279713635U, 1835022515U, 3584587704U, 3558463580U, 4116045317U, 573544894U, 4240745343U,
			3636716333U, 3900789514U, 3690167373U, 2995457003U, 3069418964U, 1475661550U, 2739534758U, 3434916179U, 2149744159U, 3591985437U,
			3026895562U, 3746814223U, 2638829251U, 3621049933U, 670289053U, 1965186124U, 2895335223U, 1718503036U, 3074887014U, 3371646544U,
			2466558921U, 2568710668U, 1903599212U, 1558371155U, 2900196516U, 3690859618U, 1527138868U, 575502556U, 1761366972U, 3569882183U,
			4144760467U, 3675837963U, 1328667348U, 3231296U, 3472408291U, 3307224173U, 915078751U, 2379903546U, 1825358123U, 1507312880U,
			2124719033U, 3735581670U, 1571677213U, 1894483399U, 4061335793U, 3253569648U, 3686832951U, 1259734292U, 3470292751U, 313251548U,
			2756732370U, 587424725U, 3430110561U, 1548023198U, 1030048033U, 167799996U, 1719399411U, 2719707695U, 3863274983U, 229693412U,
			781554543U, 4238016939U, 2013233654U, 3226738736U, 3388068736U, 897814673U, 1106408938U, 979830148U, 1910533151U, 4090009559U,
			1234559141U, 247310294U, 3021145866U, 3816845671U, 1704097688U, 2036841538U, 3272404376U, 1524958173U, 1925800050U, 3407450660U,
			950364286U, 3800799574U, 2878453969U, 782587591U, 3659536714U, 174044045U, 1796146823U, 1325176473U, 3028893179U, 1424446918U,
			1503422181U, 2199855824U, 3863416963U, 2683866282U, 3107240009U, 21698469U, 161846794U, 1348104669U, 2208670789U, 776281913U,
			2934679687U, 2388195931U, 1370664901U, 79400901U, 4010922265U, 731979933U, 1012535731U, 3322821941U, 1771080543U, 1977603179U,
			2343413681U, 933886282U, 538638126U, 1830739559U, 3347657886U, 4193736979U, 2992136277U, 869194422U, 24032238U, 520973713U,
			3017004235U, 3985844215U, 2314890154U, 3224574445U, 3707394523U, 54587918U, 2885843722U, 3506965227U, 3716375438U, 2557060670U,
			2943356412U, 1971560880U, 221737552U, 2062883653U, 2928367635U, 4290299924U, 1164007791U, 2662929018U, 4043867962U, 3584559812U,
			1168159966U, 4249437212U, 3260685413U, 3236585272U, 2162374474U, 210059678U, 147622915U, 3498987573U, 4232361654U, 2795087222U,
			1688084347U, 2990261434U, 407506332U, 193857394U, 2213099137U, 3079065340U, 1692262917U, 1172334701U, 3038146110U, 2778885759U,
			4258302804U, 2443054976U, 1586105243U, 357845668U, 2708444012U, 1548187660U, 3394469263U, 2834251136U, 630558674U, 3603090240U,
			3837258296U, 2355539412U, 1301200864U, 1272834762U, 3821621232U, 1815074765U, 573631837U, 1809993539U, 3207395395U, 3647526420U,
			4220423131U, 2021183846U, 239463304U, 337326273U, 210432183U, 1039816450U, 33470264U, 742808811U, 515065102U, 2485464991U,
			4050719306U, 3155513824U, 3929940238U, 3205731506U, 3461454827U, 1692705336U, 1795879167U, 1072981881U, 2395878602U, 387731949U,
			678895680U, 2796228747U, 1332268263U, 3219907182U, 654615510U, 1802489866U, 1665349885U, 1673178884U, 3450515878U, 451478313U,
			1088408561U, 763039775U, 3183820762U, 2853311264U, 3938856797U, 2301081480U, 2428789160U, 170079198U, 1192640914U, 4065983256U,
			752123292U, 3071013154U, 619119961U, 2767535440U, 4055679449U, 825132574U, 1567869631U, 1324471603U, 2147454203U, 762261671U,
			2157216690U, 108389285U, 3589204059U, 1280848374U, 2043484606U, 1374314196U, 535519994U, 775199042U, 3373756481U, 2154474015U,
			3680094352U, 1652136760U, 1329834779U, 3537822586U, 240688573U, 1695968957U, 110386940U, 3996618473U, 1616453001U, 2470363940U,
			3538698096U, 1861976055U, 3609141403U, 3450862885U, 198144906U, 2906416417U, 486086238U, 2519423775U, 3776046436U, 2899591584U,
			813224532U, 2175418353U, 33218945U, 2788924626U, 3217383369U, 3355050267U, 969096385U, 3540106214U, 2689030886U, 3537675211U,
			1360465596U, 2129695324U, 605152286U, 3375414081U, 2174367736U, 2016611261U, 877127890U, 2007270527U, 1496254933U, 3027687141U,
			4008825653U, 2279856262U, 3274306678U, 3065582454U, 2889258159U, 4249339143U, 395266905U, 3346303678U, 123440651U, 2326753521U,
			3155024687U, 1315783781U, 4178974521U, 4039841358U, 2174599537U, 1553743958U, 2972794606U, 2987583448U, 516082158U, 1728977484U,
			1221842238U, 2802110792U, 495036940U, 4246154310U, 1798702205U, 1518312542U, 84858653U, 815916731U, 632578216U, 1159843817U,
			76625254U, 2048729010U, 4025946495U, 1604824317U, 4127134333U, 1170792495U, 3498737632U, 7333126U, 1423932736U, 3294983301U,
			623984825U, 985477073U, 793365749U, 2077400112U, 1441974500U, 1036059932U, 1274678911U, 4141949737U, 1752319332U, 42882683U,
			530258948U, 1306867390U, 2338789808U, 3579144753U, 1225297571U, 1302612927U, 140187098U, 3547817711U, 2258721822U, 3224861969U,
			1367401809U, 2486941995U, 2287301133U, 1619515827U, 2646599366U, 2198779622U, 1183712942U, 1324379646U, 3545400461U, 2777821936U,
			2717817821U, 2981922261U, 3251275911U, 4037905089U, 2309302574U, 4204370991U, 4202962663U, 1976259975U, 2580171563U, 2460339689U,
			1926620426U, 3714794850U, 178977025U, 2314793919U, 177191959U, 4260391054U, 2115983282U, 209380435U, 3250334043U, 1644496799U,
			2802619889U, 3262615377U, 292013744U, 1758543138U, 2804270061U, 1201033959U, 81291685U, 1100406534U, 2402761132U, 68369323U,
			1244179474U, 119825745U, 946325258U, 1545729619U, 3491515183U, 250633712U, 190712312U, 1387086646U, 3888915643U, 2834311498U,
			1808828924U, 1515060234U, 4217119157U, 1349660509U, 3152605104U, 3714261825U, 528518554U, 2109127356U, 1444611451U, 2683407313U,
			991310402U, 819530882U, 2175021975U, 2556224311U, 1549814717U, 1097989922U, 3074880791U, 2291983285U, 4265937875U, 2544355409U,
			395705548U, 552566142U, 3488839141U, 3501507758U, 193193444U, 699385049U, 3629201929U, 4036211779U, 4077633387U, 3263023051U,
			2249078208U, 787568778U, 2165305673U, 4191061329U, 389874728U, 67959716U, 2324649964U, 1451840006U, 3234852336U, 892734275U,
			3986873904U, 910534829U, 4164424998U, 2972771582U, 653854808U, 1287999889U, 1368517373U, 2385001812U, 1876898745U, 3866413416U,
			2798360596U, 3905098303U, 170546410U, 3188239697U, 511824661U, 678717141U, 1350206001U, 4250662997U, 2104890751U, 3050101681U,
			3337590422U, 1007876499U, 123175748U, 1898064188U, 598888944U, 2924822890U, 3543136863U, 3382377597U, 4047592073U, 1746370456U,
			1612028772U, 1464815643U, 1380968406U, 1601112367U, 3430533923U, 3826864553U, 2943505683U, 516972123U, 47530808U, 3175189322U,
			695737900U, 2276895822U, 934848234U, 2547134484U, 1760916523U, 2321378654U, 3351429626U, 3925004151U, 583545942U, 3924019524U,
			3516339288U, 2561276972U, 502578112U, 1351991209U, 1752790981U, 3902907082U, 649142229U, 3974903257U, 4226750308U, 2892933601U,
			4291097247U, 2033535695U, 1683423117U, 808065268U, 800404384U, 1673725486U, 127975445U, 3884908104U, 2379585U, 3004078528U,
			3386176799U, 1698959773U, 2426941405U, 1493865446U, 183844790U, 326520605U, 1137584821U, 2650677998U, 4795175U, 1349577418U,
			1858121952U, 2164351363U, 3688222936U, 2928035401U, 2397574415U, 4133029702U, 3488992579U, 87190086U, 2070609506U, 3902534520U,
			1388082814U, 184645859U, 3785226345U, 974476913U, 1235005929U, 3725601371U, 1108186681U, 214913878U, 2560037049U, 3414390245U,
			665856119U, 1789997514U, 2934960607U, 676159658U, 232803825U, 2650313020U, 976896474U, 2429097543U, 2295045641U, 3221727710U,
			172374260U, 3075007797U, 3380678313U, 655055505U, 3291403276U, 2660741431U, 1857421854U, 377757814U, 1627017923U, 626450417U,
			4131929975U, 20555108U, 227891551U, 251736322U, 3068396990U, 2894815291U, 1940019608U, 894230888U, 1874428919U, 100863972U,
			1702497589U, 4103437984U, 2862372203U, 71868993U, 3212316811U, 960123197U, 1519341031U, 1591743230U, 2035574290U, 1232825381U,
			2272921875U, 1610150291U, 3034550408U, 641725733U, 3308341795U, 3902427652U, 2840002598U, 3870671367U, 240463686U, 274082740U,
			3352970123U, 1253227558U, 3565116887U, 3016487033U, 2304909549U, 462501125U, 491493708U, 3276636237U, 1933596719U, 1921516262U,
			1024156995U, 4164444323U, 4190235015U, 4242724493U, 3980444109U, 2471675362U, 2072689851U, 825082087U, 1724621976U, 3211199151U,
			906915059U, 565367944U, 1825244543U, 2516755870U, 1277940991U, 266627479U, 1700950028U, 2371265827U, 1143865218U, 2709066760U,
			3156906813U, 984104492U, 1035940258U, 1105390398U, 2168743417U, 3095463207U, 1531985827U, 251039185U, 3213304969U, 4049581863U,
			1001556281U, 3786201044U, 2984335518U, 3123743102U, 3727405046U, 1031812017U, 4261212804U, 1093712635U, 1226688439U, 1748581078U,
			3704238617U, 1890353386U, 2568295811U, 1089020599U, 1446879268U, 937448968U, 1815019379U, 133213780U, 614402420U, 2950750153U,
			2512334298U, 3750717714U, 617833996U, 464054919U, 430062679U, 1190303272U, 2781463137U, 3007340722U, 573754925U, 227408647U,
			3264392134U, 839322645U, 3980786024U, 3245118050U, 2787593378U, 1737449303U, 2698720894U, 3563646690U, 4255367426U, 3713730591U,
			1327375222U, 101655241U, 2518426067U, 1258443886U, 3811310244U, 2747018102U, 1595202872U, 1023331916U, 1420931838U, 4078681661U,
			656069198U, 60824570U, 223143214U, 1767239558U, 2267596687U, 1000122521U, 1738235962U, 1812039927U, 768097648U, 3138552725U,
			3179476253U, 1958024809U, 724560321U, 1976971744U, 2376701108U, 1925122438U, 2165046773U, 2265670329U, 1748124534U, 640025282U,
			3245441097U, 3662161667U, 3614908551U, 2338778935U, 497382587U, 1646217150U, 2132674799U, 1981109634U, 3890613866U, 2642032711U,
			848045899U, 3709456983U, 1389294463U, 1370307091U, 4094627210U, 1133637128U, 3959350173U, 3101677495U, 497879539U, 408500173U,
			603485050U, 4135841716U, 3371158649U, 917566903U, 3170550548U, 192748732U, 2688328407U, 3362631523U, 2343347828U, 2511263840U,
			3037890898U, 3534738996U, 3912797114U, 773697170U, 874026149U, 1320783101U, 2653965588U, 2805446711U, 2026721664U, 950113210U,
			3915075092U, 870231652U, 1828366244U, 4147937932U, 367609899U, 6100192U, 3566095977U, 1879294215U, 3526235512U, 3921020572U,
			2165290014U, 2089024836U, 229389310U, 1923385087U, 2851999719U, 1708920678U, 1710054448U, 4129021651U, 4241467500U, 2808790191U,
			2093947809U, 3224085354U, 416079533U, 940468018U, 2013408604U, 1298722992U, 3888427818U, 1866861975U, 4185629780U, 1373367005U,
			3481289806U, 303827993U, 170973891U, 1271237966U, 3461651272U, 1188310462U, 3421576361U, 4034022599U, 1723077907U, 2477654344U,
			256876627U, 2106074029U, 1111326531U, 1873467088U, 2434698083U, 1756990423U, 4171738688U, 544769760U, 3540141126U, 1087095781U,
			3979413698U, 240240729U, 1860690477U, 44144059U, 1129467965U, 1612351152U, 977988641U, 3240050565U, 1560026650U, 2362660222U,
			2374717663U, 108317171U, 4048466579U, 3483836628U, 1217000834U, 1672331491U, 2047944111U, 2162275595U, 580428189U, 3225830762U,
			2042820975U, 1230708699U, 1405760291U, 1407374703U, 2297341164U, 2949093919U, 4251385587U, 1115359502U, 3049732669U, 1031757763U,
			2462954470U, 3221639949U, 1545592022U, 3152385559U, 2565109703U, 772767013U, 1955272372U, 481870153U, 3124721601U, 3060786272U,
			646817261U, 958430273U, 3254368484U, 1324451063U, 331786561U, 4188467599U, 800829908U, 1773369302U, 706265719U, 977872322U,
			3728883077U, 781192723U, 3921883085U, 2255801833U, 624331617U, 4113818283U, 4081375385U, 677939045U, 3711770502U, 2608966580U,
			625671249U, 3160069935U, 1464450097U, 550067582U, 2604159583U, 3520965089U, 4209762387U, 895995311U, 1753623662U, 1547375932U,
			1886177669U, 1316292853U, 2971753869U, 3218385939U, 2621282240U, 727501569U, 3671343610U, 1317614418U, 936764618U, 3367748272U,
			4216366829U, 3289469874U, 1804651540U, 1124475878U, 3985648838U, 7757386U, 1473353954U, 1396404992U, 3690151062U, 596011016U,
			1798591674U, 960176213U, 3792177217U, 84905255U, 2249075811U, 553877375U, 3250908271U, 1097542543U, 123222795U, 3731790311U,
			666533901U, 582009352U, 4054718277U, 1721838882U, 14607782U, 3615127750U, 2320759026U, 168385347U, 697877543U, 3597210093U,
			1435069144U, 958206750U, 703183297U, 2328486663U, 538756252U, 1608611338U, 1265369946U, 2444564484U, 921963448U, 4237788423U,
			315817101U, 1777143890U, 924921933U, 4254495889U, 956745109U, 870964515U, 4212357272U, 2845781299U, 4259906407U, 1373100320U,
			776575142U, 2249342514U, 1200423698U, 68551966U, 4207233924U, 3443893801U, 889653227U, 2668640998U, 3604759362U, 3338213309U,
			2528690981U, 2567794182U, 1622023113U, 3449997742U, 1046717919U, 1326978409U, 2605056911U, 2290079310U, 535219826U, 2361994833U,
			742590478U, 3062689901U, 4292120321U, 3184792819U, 2724392109U, 2737074888U, 1827157545U, 921346405U, 2344621154U, 2782287673U,
			1962059627U, 588349654U, 1919605990U, 2639707092U, 3677665633U, 1953419816U, 2769463280U, 3804074530U, 3596294083U, 4040506088U,
			3383493115U, 3798621152U, 3763449911U, 3562759369U, 1518224346U, 430845216U, 1168558571U, 3141589989U, 1249637631U, 2280776374U,
			364059981U, 5304205U, 1015637908U, 852907640U, 2099494572U, 1207421395U, 3545111866U, 1052977591U, 3915262486U, 1080387352U,
			3760164602U, 2494869400U, 202679671U, 1743642443U, 4076519834U, 3403220086U, 872939940U, 4102792525U, 3351659634U, 108101458U,
			694492918U, 4281716779U, 2169475350U, 3529650473U, 1223102387U, 856887103U, 734881460U, 96589075U, 2764457518U, 1900110872U,
			1214502073U, 1916281142U, 341740616U, 969110087U, 2759418088U, 3701070451U, 708030861U, 2420518476U, 2086363836U, 2492746703U,
			496687788U, 2337603362U, 1770228549U, 2675762642U, 1267951569U, 933316754U, 4251964216U, 648970192U, 1562746609U, 3673524971U,
			3489800692U, 767216947U, 1675901548U, 3128697256U, 3911359681U, 632161406U, 3807588017U, 1869875643U, 48863827U, 648335781U,
			4071136717U, 3558557163U, 3245298365U, 3361604563U, 4179930208U, 3352571177U, 1184932482U, 2430606022U, 3994003485U, 2203277012U,
			3785515140U, 3246331048U, 2591154947U, 566559043U, 1879576041U, 344813377U, 158954245U, 3548628984U, 597591017U, 59716179U,
			2281701804U, 1723423105U, 1572794704U, 3834110832U, 2127004446U, 1574412466U, 1302804388U, 125857708U, 795437972U, 3762564661U,
			1545709589U, 3320133201U, 2675183552U, 266655248U, 787229170U, 2061512564U, 1392447605U, 2916646087U, 3816587093U, 334782582U,
			3487217352U, 1652841051U, 2930687728U, 2134777881U, 2347312031U, 2412899843U, 2782545550U, 1991522788U, 151757091U, 2244340245U,
			1850630947U, 1804063896U, 3017782056U, 324811640U, 2280558319U, 940054701U, 2408633613U, 1092131836U, 4285356134U, 773045891U,
			2756255767U, 1719243357U, 2692001570U, 1904919058U, 3613693292U, 92814431U, 212731261U, 511516381U, 2728708926U, 3766922402U,
			254962667U, 1856426261U, 2542822280U, 2150952594U, 1786567067U, 3498911087U, 3335964096U, 3477243353U, 2242373065U, 2701253908U,
			481805074U, 771045580U, 814148878U, 2160480929U, 115427924U, 3679787781U, 1325058821U, 2238946617U, 2025178268U, 1559861186U,
			1069053718U, 2067085086U, 1371173115U, 378756894U, 3487431787U, 3436595498U, 4146043298U, 4204271545U, 327241972U, 4195558271U,
			3223289635U, 551256685U, 2785496089U, 464998778U, 2784125927U, 2930268759U, 3630697982U, 1794471986U, 2631290886U, 3659958518U,
			4225485722U, 3549528228U, 1010829714U, 1992306320U, 1627890144U, 1446654987U, 1123433773U, 4133428071U, 510669715U, 344688211U,
			1152470318U, 2990266638U, 1912388313U, 2862366853U, 2219840294U, 3220015220U, 2766760473U, 1226875874U, 2764467072U, 2133404540U,
			587729697U, 561588002U, 1764842907U, 608878303U, 2332713480U, 28337429U, 2421704598U, 3454261411U, 1760291070U, 3468892267U,
			631264407U, 1835377475U, 1822501569U, 2247987873U, 300217697U, 1743755753U, 3000939602U, 1723875518U, 3239431064U, 4076107597U,
			2567057156U, 3406046292U, 1803526193U, 2478400778U, 3137528825U, 2397071359U, 2484503925U, 995593619U, 2552498929U, 2237730473U,
			3393322732U, 1993675135U, 1079036804U, 688208865U, 4149123532U, 2915803052U, 1675375090U, 3993721287U, 3880331913U, 1922427570U,
			3387555462U, 4195124490U, 3921710625U, 2402549766U, 313819142U, 3994915102U, 3314671441U, 543377554U, 3480231135U, 2488864635U,
			3293138891U, 114381112U, 112541601U, 3735002859U, 662360221U, 888743531U, 1508495032U, 2676175293U, 2789986481U, 3769755543U,
			1330478332U, 2730942353U, 507288914U, 1136990650U, 1053445357U, 1521080294U, 502727439U, 2959728798U, 2447307623U, 3694113715U,
			881046549U, 777801623U, 4255400211U, 1602379816U, 2582675158U, 3843456819U, 2696938154U, 2782613498U, 216188066U, 2606540138U,
			19472171U, 2964583199U, 1671225980U, 3922618718U, 1983809144U, 2720577606U, 1943486257U, 2684705223U, 1234994022U, 1004476564U,
			1335589661U, 3543324702U, 924815338U, 58045764U, 2221088662U, 2649367426U, 341095465U, 896095423U, 3572666139U, 1305583746U,
			2481697209U, 903318872U, 2991525172U, 28840419U, 1077237647U, 1168268179U, 3614595362U, 2104201358U, 527670857U, 758902734U,
			2757969740U, 3821526050U, 2155468058U, 1383148823U, 2015061280U, 3335132820U, 912535567U, 340219313U, 3808321598U, 3186525655U,
			67684564U, 4194074864U, 3064467134U, 4273606854U, 76629469U, 3177421793U, 924270800U, 2236490553U, 697569835U, 370860593U,
			2916903309U, 111201735U, 3445864146U, 2348268317U, 2873396584U, 3608024217U, 2297165625U, 346106262U, 1487637318U, 3275695359U,
			2331766869U, 1045978399U, 3924953791U, 1412180521U, 1445201719U, 4009955424U, 1407776856U, 215129861U, 2671158586U, 3763981404U,
			50515546U, 3779530301U, 1326410452U, 633242656U, 918649095U, 3703171452U, 3963134396U, 1212653915U, 2019836207U, 2506456075U,
			1910630260U, 503079988U, 2999579673U, 1506094908U, 3945780073U, 1018822943U, 2951784067U, 1398926324U, 3005309316U, 717235552U,
			3133151959U, 1422478016U, 2640956613U, 2120122062U, 830047701U, 177778624U, 3271991U, 3956542928U, 2011827779U, 964030304U,
			1172583254U, 454031311U, 3644586410U, 965336662U, 3266373614U, 859295755U, 2856936058U, 592880027U, 3153014700U, 3187837203U,
			3531356369U, 1707259790U, 3378497012U, 528755721U, 2908719772U, 858186598U, 347736943U, 3094565271U, 2937812102U, 1786626306U,
			659309393U, 597079030U, 3028535693U, 53959523U, 3800981257U, 2258826964U, 1515642724U, 615417657U, 2410006548U, 2651567466U,
			2882087331U, 3409685672U, 1316285724U, 3803011507U, 3084906526U, 1848853133U, 1313865292U, 2933757231U, 513060728U, 576745544U,
			1088420323U, 3205585942U, 1469976048U, 2377853409U, 3963188980U, 1259295120U, 1781880462U, 2100912686U, 225794623U, 3867701462U,
			2311230020U, 3938498881U, 120050514U, 3832954168U, 2099346290U, 3342338450U, 1240215718U, 3517047882U, 4180499914U, 165128116U,
			490400478U, 3633449410U, 2174094375U, 2473361350U, 3710105219U, 283016886U, 1245559294U, 1460971885U, 3582155880U, 775781285U,
			4011809145U, 3711693893U, 2187831257U, 1738434477U, 2062558141U, 3707673600U, 2815971050U, 1447688390U, 3478730538U, 3792013849U,
			3048439681U, 466344817U, 1247846505U, 2034332846U, 2456695384U, 2736011453U, 4288156088U, 2433271240U, 3515384653U, 4194224110U,
			71235736U, 3909686715U, 561574321U, 677007493U, 337200887U, 1216426552U, 552515074U, 845427510U, 2572404775U, 2604246918U,
			3458442158U, 1286150942U, 3111754633U, 3660801426U, 3947383328U, 3152712194U, 3006762549U, 2255208214U, 2518974049U, 4053349030U,
			1716183835U, 204590140U, 758930424U, 224840526U, 3565468617U, 1098003986U, 2404727717U, 2087845856U, 1712172404U, 1081438314U,
			2016805125U, 1420886992U, 3508337128U, 1430976840U, 3797546189U, 625534926U, 3759981236U, 3141942683U, 4037854791U, 2225279771U,
			2237381130U, 2021892360U, 67165733U, 866835499U, 2086815978U, 4238614963U, 194497853U, 1843926773U, 3052789312U, 254855618U,
			3776993565U, 1116776605U, 3901332612U, 1426662628U, 418434723U, 1020023923U, 1763537152U, 2201312628U, 1097775512U, 3439801716U,
			559262647U, 1997673376U, 3723885860U, 3755852228U, 3093284458U, 142034255U, 1604088681U, 2886370168U, 3251436123U, 2856564963U,
			2734631276U, 2243829145U, 3128930421U, 2986614132U, 1665248157U, 2493796062U, 1377874866U, 106840073U, 2035966793U, 3068556294U,
			738078041U, 1420471732U, 3657137362U, 384596737U, 4564520U, 2888596887U, 731510378U, 3667677413U, 925294212U, 2392387909U,
			1822626836U, 2436545U, 2730379181U, 2506951227U, 2642126927U, 220033162U, 3862293821U, 911681943U, 1218150329U, 1219032815U,
			105010432U, 3034412701U, 505808188U, 1383024892U, 1514166388U, 1194494372U, 789044543U, 2428276743U, 4090372193U, 1762767368U,
			1695934823U, 2080769883U, 3169398612U, 4259088653U, 2981168645U, 4075092195U, 1133388229U, 2221403257U, 236020838U, 313484260U,
			1756343540U, 3648816452U, 2359361113U, 1203946889U, 4028544599U, 2537871524U, 177759716U, 314345222U, 3049171695U, 588154221U,
			3593422658U, 3626775552U, 3840748271U, 2821584596U, 2119854351U, 3918815919U, 4243506499U, 1641699654U, 2454478373U, 1524251224U,
			628380211U, 684920553U, 2364966077U, 2241625076U, 1796402487U, 968635249U, 711300017U, 1633301926U, 3022139514U, 189378781U,
			629834845U, 3376242817U, 2268028230U, 1615118323U, 818335654U, 2589660453U, 4051473097U, 363652395U, 2259508860U, 1659462677U,
			1049842268U, 3323546456U, 2670333339U, 3295745755U, 3269050005U, 2198684446U, 2460416720U, 775170593U, 3610177194U, 1843191434U,
			3550115243U, 3314099088U, 1869031622U, 1828291636U, 4001449710U, 775501505U, 3143531504U, 693407817U, 4105121036U, 3481846984U,
			2297034963U, 2893208179U, 1443344563U, 2889047720U, 2884261343U, 2039166464U, 1433097638U, 4169123960U, 12651552U, 4143993045U,
			4244167449U, 1331273372U, 2011839895U, 4072650795U, 2875169146U, 144646873U, 1302604307U, 824437128U, 2803379878U, 3302527557U,
			2664931948U, 1977333028U, 1790286276U, 619659887U, 3837647887U, 1082151532U, 1720815752U, 3579968971U, 3281820288U, 2425409578U,
			575559274U, 1364467326U, 3598374437U, 2067921292U, 591677872U, 2799360713U, 3436775963U, 1802933088U, 2041586735U, 1898814198U,
			3462986029U, 1387292857U, 1667299210U, 670849385U, 2884194830U, 3400711337U, 1049702273U, 996655627U, 1897414307U, 3775238002U,
			2486296430U, 3421766692U, 1071205735U, 3581394780U, 1965906293U, 2732070680U, 2122837400U, 1189307594U, 3839458919U, 1299066665U,
			2532197705U, 3581334769U, 1837923397U, 1126921702U, 2138169588U, 2324962453U, 4101179831U, 3926118983U, 3427382689U, 3454949810U,
			682064186U, 887860488U, 1334301379U, 1880763818U, 2459894665U, 3509736698U, 2200231116U, 1790572582U, 50094412U, 3645694717U,
			2766423592U, 1466202543U, 2365111873U, 2681937351U, 2184259588U, 3329008475U, 1122691717U, 3985075447U, 2281239831U, 1815108541U,
			4232917106U, 136387170U, 3445001030U, 2472779153U, 3885370768U, 1152167630U, 4035868677U, 2222768483U, 55585450U, 333368629U,
			797762493U, 584255822U, 1096255836U, 1793301253U, 2584804022U, 3793340724U, 1879194636U, 2493327519U, 1485673919U, 4243239470U,
			1491380184U, 3029144284U, 2933486260U, 2551412719U, 352790552U, 1125594U, 2680718135U, 3295281594U, 797693384U, 242168792U,
			3259591660U, 3462792325U, 1043459263U, 2960919172U, 259516597U, 2778407349U, 556986381U, 41281179U, 1754332465U, 2419763779U,
			3169724959U, 1937643974U, 1405838496U, 4255843925U, 1157613804U, 525659017U, 197405940U, 39972239U, 4164363596U, 87997554U,
			3500787058U, 3887553587U, 1038988020U, 2062653710U, 2469953078U, 484701985U, 832189069U, 414778734U, 751170910U, 1083872428U,
			1013594841U, 3792932563U, 225414468U, 639749964U, 2198422949U, 3043383280U, 3416235206U, 2798123477U, 1282364777U, 2326282680U,
			1922446336U, 2330026546U, 4115255345U, 2458565227U, 3850336243U, 682237548U, 2657401859U, 179181431U, 720566122U, 460828123U,
			1759730744U, 965276867U, 1810058133U, 2569222452U, 1214967485U, 412955587U, 3293077615U, 1622633124U, 2403078699U, 2104459633U,
			2448742637U, 972709967U, 3339798641U, 3570222531U, 1264736702U, 2164080130U, 914590981U, 1653501504U, 3011963388U, 3690489400U,
			811158226U, 3572200968U, 3575353486U, 2331486260U, 2613694636U, 3377231700U, 928977704U, 2963991430U, 2625181513U, 1178374543U,
			2350097485U, 267365426U, 2303694708U, 1946472938U, 1341973634U, 1788324430U, 2294119777U, 119012664U, 3514895613U, 1132231343U,
			3892357148U, 771322561U, 1358847257U, 4110866303U, 655241572U, 3559152552U, 2285150676U, 226581507U, 3632272912U, 1445110757U,
			621488540U, 3424412395U, 2014317367U, 2498310702U, 2061281922U, 447364093U, 2196290855U, 4068026413U, 2344222410U, 3030265232U,
			3189832718U, 2024757080U, 663853532U, 4244770699U, 882137649U, 235741750U, 2527901026U, 763581059U, 3425708683U, 2569294033U,
			2766512590U, 2642436700U, 240138109U, 301268481U, 1903961092U, 1224166945U, 1620538778U, 2894716879U, 1407151947U, 131724577U,
			3566148007U, 4032118196U, 866482691U, 2959433808U, 3511863235U, 1207920933U, 3521133204U, 156103655U, 1467454474U, 3483564207U,
			2689960907U, 3819301307U, 4090346397U, 2789913898U, 541183264U, 1621472702U, 750834099U, 4227463410U, 27938109U, 256656861U,
			2423917504U, 4165864154U, 3089730545U, 1534256317U, 3125915183U, 1699019411U, 3857988489U, 2465861676U, 1733528180U, 1118268100U,
			1004957346U, 3919387899U, 2027295113U, 1024325000U, 4129976815U, 401134053U, 2512588928U, 1455534448U, 2481476160U, 399648365U,
			2893592893U, 1709517266U, 3653649571U, 3618586415U, 1507371094U, 2014967506U, 2034694977U, 616518265U, 1747601361U, 3835560908U,
			3878753296U, 1917090895U, 1605734572U, 438779895U, 3557349630U, 1313787070U, 2008821964U, 2125212004U, 1387412033U, 3679272579U,
			1079254300U, 4210486856U, 3950858722U, 2359671863U, 1265118285U, 1169627032U, 973881977U, 3694799082U, 2889831449U, 2252842353U,
			3043390090U, 3052442878U, 3490293098U, 3110596500U, 3293007593U, 917720458U, 2557533304U, 1677385012U, 2131464284U, 1578439744U,
			3985274837U, 2298365246U, 898219763U, 2704942871U, 695021788U, 2285500570U, 594867385U, 2020157705U, 137237596U, 422036837U,
			547820357U, 4024593648U, 1642751352U, 282823273U, 259070855U, 3352216361U, 3454407122U, 589794456U, 3994150973U, 706765320U,
			1836441209U, 1403986566U, 1809092178U, 3003093464U, 1921587415U, 3450305548U, 2602828848U, 1406824118U, 2172335292U, 2504422920U,
			243571508U, 1583907127U, 3732469462U, 3790395033U, 1915199633U, 4171825687U, 1726733155U, 2221353430U, 827986780U, 1747357794U,
			1417187664U, 1000494867U, 272296149U, 1839482794U, 1838140373U, 886792617U, 2162745059U, 4160673789U, 2637890709U, 1166107328U,
			3527438981U, 2321822706U, 1934318060U, 2843435508U, 912158230U, 2373455890U, 1111234522U, 3356393359U, 2051613479U, 654568805U,
			3947341976U, 792259079U, 703901045U, 3764431754U, 1284191375U, 742606528U, 2911207807U, 314328351U, 4283055275U, 1077127104U,
			3393107985U, 582774866U, 416492238U, 2813406623U, 4122572279U, 591547904U, 3948166738U, 3769443281U, 2769404U, 1436185691U,
			3527813768U, 2141907837U, 3575207585U, 1253446576U, 514731344U, 3201081144U, 2504910985U, 484251046U, 2977815262U, 881473263U,
			2050676085U, 429525212U, 105770756U, 3367819432U, 650496738U, 105591761U, 3703569560U, 252340995U, 3814185085U, 1886030342U,
			1980385930U, 3310103822U, 202281134U, 2991937977U, 1253012743U, 1367480463U, 1859679771U, 156481824U, 1379732239U, 2961991817U,
			1709157897U, 1792807687U, 3511363405U, 3419846046U, 620590701U, 3767500207U, 4252516934U, 2996383134U, 68034873U, 4089519046U,
			3184372477U, 93302619U, 2327082571U, 2286749650U, 710871703U, 4225988080U, 1594146959U, 775910350U, 1151232047U, 3365409546U,
			2112314869U, 69486236U, 3445306115U, 759863918U, 2918438399U, 1410477271U, 3750476261U, 2796565958U, 1952843811U, 3541339524U,
			1400435371U, 2983908432U, 150551627U, 3926991080U, 2167525798U, 310286478U, 704050438U, 4083405785U, 2411813861U, 1148335940U,
			3390022013U, 490718749U, 3956879332U, 3273004177U, 2057785077U, 551616212U, 3836973775U, 2319402699U, 2577461129U, 1423795517U,
			817522012U, 3737628505U, 2580126503U, 3146918398U, 324589079U, 2359352037U, 3580824530U, 2816834479U, 3322715155U, 2662784479U,
			1208810988U, 238392707U, 302084690U, 2650824610U, 2201390607U, 2745863014U, 1589061690U, 2989044605U, 1195420282U, 3761708920U,
			1944860539U, 2320935122U, 664101187U, 2914922485U, 4141291681U, 923392501U, 1466234879U, 2282943970U, 4155153334U, 3163874963U,
			1136396515U, 1588503076U, 3446753228U, 1195798165U, 742838522U, 3371656258U, 4250460345U, 1177110387U, 2782175594U, 1059102506U,
			3137774433U, 2951513387U, 3122060943U, 1374192107U, 3176806396U, 1764257008U, 3910871079U, 2539119935U, 911401055U, 2330687606U,
			2630892611U, 2552266125U, 745624412U, 1495040302U, 3216315227U, 840117159U, 2144745370U, 918597821U, 77519624U, 3463059629U,
			3129370478U, 3761709001U, 2771614882U, 1407432581U, 428300712U, 4268184115U, 1909113002U, 2012135004U, 1227254499U, 2881801802U,
			595361778U, 451235026U, 3856735392U, 2537292808U, 1452864652U, 2647703582U, 606178824U, 3538246853U, 3215358129U, 2108113765U,
			1760232551U, 1213732572U, 2199347653U, 1752924862U, 2704172908U, 3503637505U, 1042610720U, 667723267U, 2224880U, 1789420238U,
			2792236388U, 563839052U, 3188624512U, 2615111757U, 2681455428U, 4289692157U, 936744745U, 3565693252U, 3267762770U, 2991160802U,
			1914016663U, 2854463689U, 2569974150U, 255112197U, 3421460188U, 416346037U, 3942373348U, 45512381U, 1832072009U, 3204980026U,
			1310057392U, 1201740696U, 3884401109U, 2589942962U, 1211090754U, 466589123U, 3686154409U, 1450996583U, 53736768U, 8533035U,
			3511566177U, 3199563187U, 3683672858U, 4238656531U, 812845510U, 357445346U, 3079140907U, 2401056086U, 4011259670U, 2768938400U,
			920432154U, 2338446865U, 745286174U, 364593416U, 190939069U, 1327744596U, 753656022U, 2507078917U, 1597730923U, 2290645281U,
			486522297U, 1669122313U, 1805451211U, 1445575725U, 2099539421U, 688227962U, 2203373530U, 1876180998U, 557335822U, 941023849U,
			3587998765U, 981641242U, 4201831238U, 3126186331U, 3762851506U, 504794796U, 3591028067U, 636677274U, 2986235162U, 1731406010U,
			264524388U, 2070144090U, 2015440510U, 1731165511U, 4275713659U, 857918899U, 1984935385U, 196334492U, 3999184713U, 3404075318U,
			3705663174U, 2460390333U, 109792890U, 367309119U, 2305782363U, 2860938552U, 775252881U, 3064622075U, 152050375U, 195906400U,
			515241302U, 778005802U, 3860865331U, 143063201U, 2377813695U, 2989309556U, 1695625821U, 3071283750U, 365421037U, 2543664270U,
			2833785724U, 4166568000U, 3101687131U, 1636759557U, 4028666550U, 486628719U, 4047048289U, 1647555120U, 2486309350U, 28401834U,
			1782405369U, 3472423589U, 2169748915U, 108342081U, 4274630719U, 643254960U, 3301884261U, 2483158495U, 4269720336U, 3830621111U,
			1252803343U, 2948808789U, 2068956211U, 2442127609U, 2236884322U, 538945929U, 383512691U, 27993726U, 3266349853U, 2443578197U,
			1891641837U, 1034695071U, 725505910U, 1178830941U, 720109581U, 3501208737U, 2723901871U, 98681216U, 2954299001U, 2253902150U,
			1565354872U, 3156638710U, 881928058U, 199782261U, 601040965U, 4002923094U, 3379748460U, 778481897U, 2006128157U, 1320864291U,
			2452293155U, 2253611749U, 3753466277U, 3686788112U, 499437354U, 3727952782U, 3329431061U, 3921571554U, 1409994694U, 3924037670U,
			4154412925U, 2930963801U, 3096506223U, 752531102U, 3489625933U, 2102893505U, 659635003U, 1557706482U, 233183436U, 951134050U,
			1339402481U, 1940184268U, 1841975451U, 470387360U, 3032257275U, 2498102625U, 112967913U, 3604818216U, 1880339003U, 4032687119U,
			3054142853U, 3319414394U, 3633791695U, 3718965228U, 4280633673U, 3622053740U, 3704887687U, 694728516U, 2495046529U, 2207926911U,
			2826414831U, 608064299U, 1679175164U, 3588466862U, 1952586195U, 64600080U, 3192612004U, 1058276253U, 731173088U, 1875231163U,
			1253819823U, 1317353715U, 3039514458U, 4251530508U, 3215775938U, 2059918680U, 51657892U, 436740461U, 2727618302U, 1653705933U,
			2946707994U, 592649385U, 1356190546U, 1611360157U, 1784719476U, 156746618U, 1940822478U, 1484010668U, 2123543030U, 690149984U,
			3921425997U, 190165087U, 2234138117U, 2936482014U, 3942912642U, 2001201556U, 3728812023U, 13423745U, 1529850508U, 589242531U,
			625796959U, 3497230810U, 4235603774U, 2317905666U, 4065212489U, 860633205U, 670519055U, 635478124U, 2108260944U, 1618141692U,
			1535601580U, 3879578788U, 641300320U, 4159535783U, 3699849023U, 180612795U, 2752052834U, 1638270699U, 121497654U, 2467680735U,
			2972495562U, 4160733562U, 681255998U, 2533780312U, 1370529303U, 947895333U, 4253565237U, 3418401396U, 1954050335U, 3472473469U,
			1082566402U, 3541724435U, 243039373U, 2777314912U, 1837310378U, 458501785U, 266198530U, 1139228756U, 3889367702U, 1238873719U,
			3020333414U, 287259830U, 2358039769U, 3816282082U, 2716179280U, 773950126U, 2460870020U, 3681361745U, 307449671U, 2694515683U,
			3737391476U, 212224962U, 3550932141U, 3970574578U, 1938919138U, 4093068585U, 2386547652U, 2131797438U, 4171279325U, 3227121283U,
			3686495306U, 1577252223U, 518168488U, 3917991562U, 2978290361U, 2050525374U, 3356735561U, 1919128343U, 922582930U, 1651782740U,
			2879292339U, 2744077163U, 3548699484U, 1871914172U, 4046872920U, 3024575203U, 286020201U, 3724474426U, 957359679U, 1696242535U,
			2903658273U, 4077417102U, 2760309451U, 1226147347U, 195399138U, 943194532U, 2336425235U, 3755837520U, 3407026210U, 2215537566U,
			2621046886U, 2622593982U, 2696836337U, 819074662U, 3303238504U, 3076122530U, 2398321933U, 3060524492U, 94204686U, 3453690396U,
			346405616U, 1310537182U, 2086414780U, 1858932337U, 73315628U, 2474937346U, 3382191995U, 3714933512U, 1575975792U, 2700218559U,
			2000734248U, 2641809949U, 811666215U, 922235721U, 1024211841U, 2444618466U, 1159313559U, 700474486U, 2673101061U, 1738364929U,
			2641291393U, 2967101533U, 2090666999U, 1020196468U, 2093496573U, 2869535983U, 1232705802U, 2816117883U, 2667924060U, 1090578889U,
			529183860U, 1394500843U, 3759151359U, 134001906U, 3668955211U, 546609205U, 2655694022U, 1083300966U, 237060889U, 2825030295U,
			2474237723U, 3778473501U, 2865793673U, 783949874U, 1950946995U, 1695420875U, 1640491106U, 868412366U, 781993719U, 2960648786U,
			3637966389U, 2525476530U, 2671628910U, 1928209408U, 2045635944U, 2216946240U, 2499224128U, 2167411258U, 2157691581U, 2062954322U,
			555448765U, 4114189858U, 3002101240U, 1194451925U, 825653041U, 3996121182U, 1051136784U, 3963479756U, 702328681U, 1215580501U,
			2566095991U, 1585005952U, 1085852233U, 2778647023U, 3199393829U, 1103845943U, 2650461995U, 3639766072U, 2346142511U, 1423374264U,
			3495655874U, 42814959U, 3927097224U, 4047821104U, 2444951896U, 2969472912U, 432600701U, 2910691226U, 990036599U, 686497742U,
			2140912313U, 1364112745U, 1942468863U, 2147298014U, 1311377471U, 2226095868U, 373318317U, 1115851695U, 2791507643U, 3394442581U,
			1032236871U, 1197205288U, 117995308U, 1792070847U, 3655172079U, 3324225597U, 4145166540U, 371497725U, 2377981301U, 3061748436U,
			1908955209U, 2727731409U, 346977908U, 3468849526U, 239731873U, 4067271457U, 2747747472U, 2617414498U, 1848134513U, 1592472632U,
			4226680177U, 564507962U, 3596515874U, 45277273U, 410351385U, 3006192724U, 1238571380U, 2947302981U, 697795502U, 1966294772U,
			1906567143U, 1555829978U, 2113192398U, 1939580624U, 3992289976U, 3063166116U, 3653760135U, 41075686U, 904800587U, 681846603U,
			2282748529U, 3028769744U, 704460632U, 280374455U, 2101693772U, 405235891U, 810632045U, 3113648029U, 1083341074U, 259761651U,
			295719814U, 2764357219U, 3234977637U, 1139839518U, 1408308130U, 1626098247U, 2100567945U, 167042619U, 457084775U, 380226972U,
			2899739114U, 3729721972U, 3503124627U, 3000520050U, 659771536U, 4284819588U, 3677747269U, 805849021U, 2176504592U, 1459177375U,
			4062238381U, 3788903832U, 1328560743U, 4078881759U, 2441360790U, 3066289356U, 3549376366U, 4162469787U, 4214871987U, 3817689153U,
			3684892755U, 417537260U, 1794717351U, 650715727U, 856574010U, 1609799611U, 2199334255U, 2023966713U, 3344722012U, 725479661U,
			2525519976U, 3251538384U, 3987864531U, 856125532U, 645563518U, 3254702430U, 1416918268U, 1486342659U, 4288207822U, 3029288990U,
			1015281560U, 3450764276U, 1319613312U, 116577483U, 1178454346U, 1169670918U, 4031103958U, 2485664737U, 2678386369U, 2356370926U,
			134954202U, 3606590306U, 2398725430U, 880782815U, 139400662U, 2180886699U, 2226602014U, 4174622710U, 1136284479U, 1499674614U,
			271449061U, 3800838502U, 139873479U, 961048648U, 2713122670U, 2453482778U, 493316095U, 4214738654U, 3456747713U, 2483574353U,
			3169184202U, 3892758547U, 317608550U, 4096079454U, 1157611060U, 3783960564U, 1165113321U, 2652059326U, 1013911976U, 3571800671U,
			221305128U, 3079807601U, 2885955053U, 2211133880U, 2195146513U, 3174273934U, 3299811915U, 631273179U, 138502107U, 1847774917U,
			518976411U, 2971311255U, 1117677048U, 3708058313U, 3388358057U, 760749794U, 2443865249U, 1581407603U, 1349153212U, 3663356721U,
			1486478937U, 28203749U, 1167734177U, 4041614494U, 4116874002U, 2632485918U, 3727926274U, 2928407853U, 2960078041U, 2610403729U,
			3264875903U, 1271306776U, 1838100090U, 4213026375U, 3814064196U, 2175751361U, 3474109335U, 34416467U, 2437766769U, 2716206540U,
			1138988582U, 2773131411U, 217645951U, 2561442380U, 1718239671U, 219565388U, 3971473528U, 2209340709U, 3215405089U, 3129329809U,
			505563418U, 1478732956U, 948330022U, 619036868U, 1358521190U, 3855179712U, 2570934731U, 1419612539U, 3857045635U, 2698262284U,
			589555678U, 1160013950U, 431391433U, 2664856815U, 3012732820U, 528514077U, 392893158U, 296497598U, 1968502987U, 1715192839U,
			3868282337U, 3803421157U, 1664363238U, 343241519U, 2376841327U, 3654053984U, 1228034559U, 761667423U, 1002920376U, 3899374786U,
			3322575136U, 3927832769U, 2222112438U, 1321028346U, 428711584U, 4263889431U, 3961646955U, 434517810U, 2923823180U, 1501787620U,
			1676954724U, 1415584772U, 1781447309U, 364885244U, 1074587892U, 2401084296U, 1342546154U, 4176370889U, 223999483U, 879510241U,
			3605363168U, 1888409403U, 3539432988U, 71673939U, 3258105691U, 1114424938U, 254813554U, 625635022U, 3531482959U, 2262788767U,
			822174317U, 56835284U, 116826863U, 2214861932U, 2635043677U, 291394575U, 3031802496U, 4063180198U, 3416411280U, 103989034U,
			861121952U, 3317514214U, 3451600506U, 411390309U, 2479952463U, 3555985453U, 3524569407U, 1091512969U, 301396408U, 612984223U,
			1073306934U, 4223722254U, 1772530899U, 94384982U, 2285365912U, 553185013U, 871871654U, 2075179011U, 4165164868U, 3372220468U,
			4132427301U, 301888604U, 2225655820U, 991300279U, 3158905802U, 1064102750U, 2015104248U, 83049978U, 2463531334U, 4188769739U,
			665137571U, 2978358631U, 1635675818U, 3615692025U, 3535327994U, 3405646834U, 2171941296U, 1232832143U, 1081917032U, 2467494418U,
			2040334562U, 3355146132U, 333876936U, 3703973U, 4015668065U, 1245615455U, 568309052U, 2448419957U, 4277664591U, 2790037401U,
			790762291U, 2882152260U, 3587815681U, 3501735176U, 4091405307U, 1969067638U, 376375965U, 1164744811U, 2920966761U, 2100516258U,
			1414902719U, 1573421445U, 2825135791U, 3758828036U, 1097414395U, 4010842253U, 881230510U, 444948790U, 2003139362U, 3646390991U,
			589175245U, 1338394266U, 3739497020U, 2963813286U, 883098463U, 2306603301U, 2883961199U, 4248979730U, 567439896U, 2009802626U,
			2847782497U, 2826973002U, 1922531945U, 1610056208U, 1768577080U, 4238541708U, 1639249437U, 3197462312U, 3138597412U, 4227533414U,
			524988327U, 259163511U, 1999734867U, 147932599U, 3200941653U, 1945307302U, 1172211565U, 3142944407U, 3470572574U, 205735029U,
			1329473128U, 2593904564U, 826754322U, 3789108309U, 927096941U, 892905625U, 1144697960U, 189205312U, 2628387332U, 4249428369U,
			337215904U, 4042486517U, 3087671214U, 3573196791U, 2337601894U, 3124957729U, 3450462891U, 3977288352U, 3364456493U, 2455991295U,
			246021849U, 3429184389U, 938321123U, 3748050615U, 2059515314U, 3373066974U, 3947282269U, 10424271U, 252681368U, 3062831542U,
			1516103057U, 3370519233U, 1547650U, 174948046U, 223516886U, 2647333870U, 3552375791U, 1543442346U, 4098256887U, 3286093431U,
			2632382867U, 2924057528U, 3362477717U, 206425041U, 2889258105U, 3834548770U, 1066708401U, 2929932336U, 1272826774U, 985532685U,
			124773634U, 1845214746U, 1357968403U, 1014876476U, 4077451214U, 3312254740U, 3595838147U, 79569007U, 3077275274U, 2605697424U,
			460212182U, 2627865549U, 2991387755U, 720253857U, 133765903U, 907465234U, 1374092788U, 4024386268U, 2532765621U, 3499933129U,
			2675599175U, 4053533779U, 2798479049U, 3767576981U, 777820041U, 951630058U, 2762768446U, 172194797U, 1363874816U, 4180222189U,
			2431570401U, 2184870390U, 3160452619U, 3258179345U, 3435056948U, 473200969U, 4101842488U, 1691804471U, 427576787U, 2641212913U,
			3487177412U, 1734557716U, 561865244U, 3807608861U, 1120868015U, 1204379809U, 1415493302U, 2071060327U, 872120728U, 3372953886U,
			796573704U, 3114348800U, 2524605471U, 2771315253U, 2479101904U, 5354320U, 2376309920U, 4161448581U, 1849949668U, 287387878U,
			417660598U, 3601046144U, 2258058501U, 1771754045U, 3307960686U, 1354359025U, 1560098953U, 2965139912U, 3939325891U, 447778986U,
			1494775140U, 3354061003U, 1636633478U, 834357449U, 1317580582U, 410867226U, 4216914825U, 1679628247U, 2687407460U, 1939256051U,
			232958536U, 625835890U, 102915551U, 3967966532U, 2893497617U, 3613298945U, 2019460893U, 3352369082U, 3234297647U, 1571475491U,
			2373710315U, 57402U, 339335292U, 4289426003U, 3383655283U, 4175039925U, 2880703983U, 1692657848U, 1426851478U, 412123979U,
			1754337165U, 1111136788U, 419093625U, 1759265282U, 4181674015U, 3495386779U, 4138208785U, 1461680662U, 1845798117U, 884723472U,
			2866904111U, 2129931080U, 3918111529U, 911487986U, 369151299U, 3457994924U, 2395740202U, 2799740706U, 1397091677U, 2907588229U,
			1756989184U, 1911033364U, 2494932319U, 294719528U, 193467617U, 1905419140U, 2698424908U, 2187317382U, 618650029U, 1794849044U,
			3331671375U, 2896456473U, 3174458359U, 2442757333U, 1500906492U, 2456746074U, 3692470836U, 2322928621U, 67079517U, 3332489721U,
			324764709U, 3822307715U, 2712156042U, 2295824402U, 2826159311U, 4060033945U, 2830739875U, 1232668711U, 538554289U, 365845080U,
			4021044266U, 2126026827U, 1222474398U, 4157209120U, 2732412909U, 1375914521U, 2469603989U, 828820772U, 1534998123U, 3883948328U,
			2272999637U, 2659206472U, 2326297388U, 2778236781U, 3513462479U, 1522983178U, 524892104U, 723568150U, 133782378U, 3515651192U,
			2316081427U, 1986356552U, 1181484056U, 1951859454U, 1791492674U, 3018384323U, 3591339107U, 1465377147U, 3652309040U, 2112674578U,
			1760190101U, 1554731216U, 1129756381U, 1079019725U, 2121876671U, 3349196811U, 100241905U, 3848527171U, 2991399504U, 1879326931U,
			1343835491U, 3311344459U, 567796123U, 3082784624U, 4093275474U, 1296307909U, 1652483821U, 1158169465U, 3487792974U, 3852686015U,
			2018027422U, 3125869780U, 2970346526U, 3256456055U, 394194758U, 2899229834U, 3673678272U, 1272913100U, 2914232386U, 3824173036U,
			737601264U, 2917641341U, 4149903487U, 3941647314U, 225828201U, 906572933U, 235042821U, 1418404934U, 1722243357U, 3497780712U,
			3666107317U, 1524331910U, 1444736462U, 224455269U, 157900761U, 1089860129U, 2344789674U, 2524967410U, 3596293422U, 603258144U,
			3154078245U, 1960048881U, 12552874U, 1594921862U, 1833899426U, 742646914U, 544139596U, 1598583786U, 816827446U, 1191795184U,
			988559400U, 4237870784U, 2283153350U, 3913740088U, 1407561855U, 4276751782U, 1028723479U, 3792656698U, 3886396539U, 3617823028U,
			2302861236U, 2059475646U, 1019925844U, 1686154051U, 3763391307U, 1038858932U, 237966051U, 2742200249U, 3987610591U, 2527212440U,
			3973717544U, 1933846611U, 2678759300U, 4111409889U, 3691754498U, 3157464733U, 487398025U, 1474606933U, 4167926727U, 4240454061U,
			2682683932U, 1623191703U, 3051423023U, 1838943993U, 1311685441U, 2985098364U, 938686402U, 1221105842U, 579629191U, 1144804222U,
			4282422633U, 3017948582U, 1775002741U, 2509681940U, 3298831000U, 148812790U, 946671232U, 2120120618U, 102024228U, 3788934617U,
			3298381287U, 2370060776U, 2419184036U, 1233419324U, 4177614047U, 2802910961U, 416899411U, 831794622U, 3285451001U, 1634974399U,
			1747143776U, 765945892U, 3012389811U, 1255705441U, 742456604U, 3534715854U, 1635961881U, 2010416069U, 3183546934U, 3484615281U,
			221026534U, 2487269969U, 3795179185U, 619485689U, 3633841328U, 749586181U, 3843291455U, 2122193860U, 754156700U, 3365276947U,
			967246319U, 3026364559U, 2590710471U, 341860206U, 3951690630U, 132147542U, 3801015237U, 2523005262U, 3160764743U, 2741475030U,
			277945995U, 2041276462U, 2422089830U, 1522599505U, 371398387U, 3730710417U, 2932615712U, 2589089941U, 2263084741U, 263001718U,
			3452889043U, 1993507527U, 1236430015U, 3233922738U, 3172922997U, 3276899707U, 3821504210U, 1627017531U, 1138625415U, 2957671215U,
			3248372082U, 606555937U, 2730058826U, 1776880346U, 2665150363U, 4120053689U, 5876536U, 385616357U, 232556696U, 1484634372U,
			2727732981U, 3324431461U, 1927321144U, 728256396U, 2173923379U, 1947180103U, 3657200078U, 2879232244U, 2980104105U, 617627337U,
			1076442269U, 996586778U, 1194685812U, 1708795128U, 2832985428U, 313606997U, 273803513U, 1639850687U, 2452590377U, 326500595U,
			1105519603U, 544666748U, 437248252U, 2787267213U, 1230663678U, 288622450U, 4152932471U, 152223058U, 2758984129U, 335485915U,
			830966591U, 3726346359U, 2490455275U, 3486185539U, 2096203797U, 1920050041U, 3260690073U, 3965910898U, 2516582645U, 2632580209U,
			1282755436U, 875831943U, 4184299310U, 1926096011U, 3548361747U, 643233457U, 129963128U, 3553668252U, 755348924U, 1961257227U,
			3953047322U, 3974685452U, 611240090U, 342275885U, 1583564965U, 4238222486U, 1589927062U, 129298531U, 2262182222U, 3832536493U,
			1822116561U, 1171655310U, 2098501923U, 2593244209U, 4157323742U, 2420345380U, 3309257239U, 672862760U, 7746693U, 708359409U,
			2588553141U, 153630340U, 685982783U, 319160422U, 868601163U, 578142264U, 2329651797U, 734147072U, 2217372900U, 3222339866U,
			1395047864U, 3938132115U, 4096365429U, 3896165953U, 2260107256U, 1437801970U, 3340127273U, 678914607U, 2037523267U, 3398680191U,
			2517987535U, 2542020228U, 2181284481U, 3671649176U, 1054189352U, 1900876068U, 2121131445U, 2498329955U, 1493591400U, 3222084083U,
			1470968170U, 1904184467U, 3343355590U, 2047941113U, 1706959315U, 443911336U, 176549095U, 2413199063U, 2175791696U, 38504001U,
			3346953036U, 3055816896U, 145197349U, 515601856U, 669023789U, 420503104U, 348512319U, 182811237U, 922544288U, 1996564326U,
			422880317U, 3006096440U, 4075508107U, 1750815101U, 2070819934U, 759966312U, 3825140326U, 2930073051U, 2806128554U, 30250255U,
			3059806605U, 3497205348U, 1184623909U, 1874576482U, 578450602U, 340575717U, 3517386910U, 656174595U, 1125999248U, 1132268060U,
			2054736733U, 3796393493U, 744861722U, 4227902153U, 3206843439U, 3481092208U, 482899307U, 2143167504U, 778520135U, 2876806005U,
			1110388377U, 1327613445U, 1290615921U, 111735687U, 1765421113U, 3245061201U, 613218562U, 1270732082U, 3516721206U, 3937552213U,
			2840606966U, 1706268884U, 1750374887U, 3032899260U, 2175049920U, 408913935U, 43254622U, 2974945452U, 1781282192U, 1111129051U,
			1423591126U, 3757062487U, 2441265774U, 193680423U, 2571091786U, 4091253322U, 2632669449U, 1916527949U, 3433578703U, 3680257551U,
			2253293392U, 3528310367U, 1418905113U, 3373878327U, 3437988821U, 2010321497U, 870726917U, 817259883U, 2928074422U, 1979066694U,
			2783927448U, 2277065694U, 998676476U, 2210542082U, 2792057762U, 2064342270U, 451406265U, 3522141753U, 600328806U, 445131696U,
			3913029011U, 1072372013U, 194569368U, 4253209117U, 982689218U, 3131798077U, 3085755968U, 3015832187U, 3766253723U, 3185806434U,
			106012954U, 914484172U, 2293450362U, 3167385157U, 4089134047U, 1412702657U, 3687936473U, 788022841U, 80259632U, 1070492316U,
			3232741857U, 134633735U, 2152829448U, 514050681U, 3347282871U, 519773279U, 4014864274U, 2321158791U, 2088982450U, 1760696343U,
			1357769031U, 716487482U, 583008253U, 413319995U, 2386657301U, 4182450733U, 2209582057U, 546168264U, 2146989024U, 2131100374U,
			1708156638U, 302011100U, 2767466177U, 664279781U, 1767154116U, 2618167780U, 814792634U, 422545756U, 2150562676U, 655011789U,
			2124893869U, 2354768878U, 673264995U, 1491658574U, 3288676037U, 523464533U, 413414258U, 2416694524U, 3350657547U, 610676724U,
			3056250114U, 3834348870U, 2158126577U, 649803878U, 1607090786U, 2834172309U, 1201939476U, 2033891841U, 3942856786U, 3384072149U,
			1620039850U, 1908592238U, 2597452865U, 3516773460U, 3133154211U, 2530644508U, 1506699820U, 2124814494U, 351557853U, 2086295100U,
			137438245U, 4180761346U, 2217536708U, 168790615U, 3129006074U, 4245661720U, 1861770635U, 219661010U, 415492681U, 1846261584U,
			3068731955U, 1070613273U, 1490534141U, 3539417016U, 3259636385U, 1604641319U, 3453656371U, 727320636U, 1653157618U, 3093727094U,
			429346814U, 2418200035U, 176820542U, 1799246401U, 1989764973U, 2545154476U, 1857275921U, 2307514804U, 1285325120U, 3204203459U,
			1340229599U, 2151684700U, 1040387343U, 1922106719U, 3346575106U, 3212254312U, 3319251011U, 2273310037U, 1075241490U, 713792066U,
			2079776011U, 1873847772U, 438229855U, 220510061U, 2447784906U, 1974805769U, 2899259709U, 2373755233U, 28973344U, 971216026U,
			2047749377U, 2999165467U, 3333142417U, 4200626081U, 4041203300U, 628610975U, 2832610149U, 4244904217U, 1755093700U, 1363091417U,
			15972261U, 950517705U, 2636571562U, 1750827642U, 2709914910U, 2983920009U, 3220666749U, 3036334550U, 3028748673U, 3849233544U,
			3115406744U, 1999245435U, 3803560496U, 4035009939U, 2424561718U, 3090017869U, 26096255U, 484435708U, 2982106025U, 2753529636U,
			577880603U, 1032074641U, 1447889715U, 2014551058U, 1753277162U, 1267042427U, 1389375011U, 1018879747U, 2477154979U, 2722345118U,
			670990034U, 2937156791U, 1767005895U, 2954235716U, 3552682434U, 1920318751U, 2153252038U, 4032254429U, 2025608870U, 1532436196U,
			1794457751U, 2998652639U, 3831619198U, 207887249U, 3763800152U, 3823589963U, 2956331869U, 4057804041U, 2231790985U, 3729030737U,
			1247591546U, 347099146U, 3880444698U, 1580477603U, 2598151313U, 4262472084U, 2840965058U, 1892607957U, 1187627131U, 2871828582U,
			4067579367U, 3690634508U, 1022699110U, 139014316U, 2263082485U, 4113194053U, 2993959863U, 4089497964U, 4286348969U, 232394764U,
			2860557042U, 1592327451U, 2680210023U, 2242428618U, 240626147U, 3840740930U, 1164450427U, 1554326017U, 2085968302U, 565885163U,
			1851849656U, 3806865703U, 1039972505U, 2613817334U, 3418678385U, 1786694767U, 1599790561U, 2187947038U, 2499665721U, 2477146249U,
			3721238192U, 782967576U, 2550008830U, 3919399145U, 77625731U, 543329021U, 91282425U, 4162266785U, 3598949880U, 2596685087U,
			654910172U, 1875680408U, 2219081680U, 2247013700U, 4149978981U, 2257200052U, 382070190U, 4049085627U, 1335522854U, 4196427301U,
			1380296239U, 3712480841U, 130163395U, 1819890225U, 527687074U, 3721577049U, 2020347289U, 2016330510U, 625435056U, 626200998U,
			2748129463U, 3372615950U, 768600090U, 491954054U, 2305738967U, 1934898733U, 217313179U, 232854572U, 3237115496U, 2163312635U,
			51855336U, 2615621771U, 4193289804U, 55492935U, 215826961U, 3331836445U, 167683921U, 3412945271U, 241288277U, 4075529135U,
			1345914498U, 3792249604U, 2416890528U, 179468591U, 790457191U, 3259148816U, 704449594U, 387026237U, 321622976U, 3239646107U,
			294824210U, 3401205176U, 1411141263U, 3057084025U, 3503174018U, 1444840655U, 2799439311U, 4103491708U, 2261839247U, 1898656699U,
			833216641U, 3859119499U, 331947718U, 687352446U, 3307084106U, 2373248531U, 1202378449U, 1885361179U, 2823153018U, 2684872276U,
			3088845012U, 912810705U, 3456243326U, 1697905734U, 3327097743U, 3659528541U, 1314976742U, 1009279863U, 1391344267U, 257797606U,
			1617665173U, 752072502U, 3234956539U, 3908060244U, 1753739780U, 2275257813U, 2795328962U, 1485104611U, 1652120393U, 1012430484U,
			116919823U, 1491402621U, 299763821U, 4251285121U, 1767665508U, 3560306238U, 1358512686U, 419382586U, 587834415U, 1269571361U,
			1819287184U, 2330099961U, 3957095884U, 4531224U, 1122374860U, 2391212859U, 4223518469U, 2195803182U, 3710236079U, 3694575735U,
			1061626827U, 2055511483U, 1912474229U, 2239590771U, 2027901458U, 1545754933U, 2974926096U, 1246774211U, 2762596143U, 1962399243U,
			2211014401U, 3361090711U, 3778324034U, 2761385189U, 3523298429U, 1933876290U, 1040856789U, 2483950721U, 73470366U, 1395712349U,
			2674064478U, 4120812791U, 3861943719U, 2883124445U, 1437622658U, 4216133759U, 785841906U, 906922721U, 4112497940U, 3732248910U,
			1925181359U, 3569961010U, 803404100U, 1695015558U, 1292898145U, 2652881290U, 4233767448U, 4084377777U, 679519498U, 4168534773U,
			2527185086U, 3157953969U, 3002410770U, 1323498669U, 3993020451U, 1959517413U, 978658381U, 1654916678U, 2867998459U, 463876502U,
			1862899700U, 1668781241U, 3020144745U, 3082860577U, 2245178197U, 3967885977U, 3218763531U, 3061033949U, 3546389827U, 1365542906U,
			3721580105U, 3498410152U, 2024297624U, 1653263266U, 171708111U, 4084798494U, 1349305982U, 4198141042U, 4237278757U, 3849632808U,
			1934506006U, 2991801800U, 3960943561U, 4257100957U, 3597251075U, 1919207034U, 405530560U, 1093172640U, 2164786838U, 4036690605U,
			690602485U, 4063605059U, 300853518U, 3545318273U, 3056348219U, 582301590U, 3662548415U, 3175741595U, 2981774535U, 1733328946U,
			876546643U, 1207094015U, 1074610720U, 2151234355U, 3382219541U, 1983124220U, 4170349870U, 4025558061U, 1543079003U, 4182624605U,
			2995466354U, 254304005U, 3759724938U, 1515479586U, 2563447755U, 44148223U, 3266004681U, 3383029437U, 1424243610U, 1903919312U,
			666056855U, 618675536U, 1572750837U, 1169575734U, 2940395076U, 3624119506U, 3414089962U, 3934973953U, 2157821687U, 2428795546U,
			3136413424U, 4015077253U, 3924058891U, 1635184410U, 3605342464U, 3187643918U, 3156076055U, 4012981565U, 77331339U, 216546005U,
			1365242777U, 966362297U, 1064576621U, 1222319663U, 2526350925U, 2962056370U, 2637276177U, 2042364878U, 1466406532U, 914301894U,
			3471775211U, 2570597121U, 4131124341U, 1694407395U, 3019852961U, 411895470U, 1891133560U, 3609115944U, 1209142864U, 638426105U,
			2113779352U, 2279457782U, 1737078370U, 2603027510U, 3314061480U, 143137228U, 2677286661U, 2647460792U, 3906543839U, 2326495326U,
			8398677U, 4040049652U, 4125651245U, 1577350921U, 4071054125U, 2281623585U, 858957565U, 3190653175U, 3247814234U, 1204684453U,
			1188708624U, 118053090U, 1547761538U, 1695941286U, 1322250199U, 2817043895U, 907780692U, 865137633U, 4054353005U, 1429651789U,
			814387888U, 50431908U, 3211066640U, 311490495U, 3597534644U, 550262068U, 3494000975U, 1625469766U, 210592399U, 2152421043U,
			575611270U, 2450020526U, 1709593397U, 1234778977U, 2395644835U, 1977037957U, 849881366U, 1302039230U, 3182208599U, 2731862026U,
			1983907686U, 2358702593U, 2091969241U, 3240830793U, 756619611U, 2124809557U, 328520633U, 639944098U, 1960709792U, 34718708U,
			1939814569U, 1608571916U, 2620797638U, 759031411U, 1062927675U, 2150457629U, 4142645049U, 2665657573U, 1298909769U, 3899718390U,
			557795434U, 3188268306U, 3587665553U, 1328135689U, 2887978266U, 3055022274U, 3522789859U, 2328823947U, 1500069353U, 1276039442U,
			3346965790U, 2076953831U, 3863588569U, 3043621497U, 4033910663U, 487093851U, 605254316U, 1581111101U, 1860566257U, 4263783556U,
			2069844227U, 2531144483U, 3349500337U, 620796562U, 368709269U, 1614195251U, 2218008857U, 3160657942U, 2955694843U, 2766475329U,
			1564805524U, 2017006986U, 39682283U, 757222551U, 1276950781U, 1792197136U, 1878679985U, 818636063U, 4085030156U, 4037707907U,
			778692406U, 2818195708U, 128838230U, 4284277889U, 1888344698U, 3867540627U, 1774375956U, 1619264626U, 2751205757U, 4264436124U,
			4248490089U, 2098594284U, 1708146702U, 3981478380U, 2405924739U, 2286419003U, 959266015U, 207860401U, 2575509285U, 2298769152U,
			2050945404U, 4090544614U, 1480473029U, 3592023193U, 1782343817U, 1495390557U, 1374121222U, 28845044U, 4030244995U, 3555675707U,
			2410791707U, 3262228786U, 1817032921U, 1113347025U, 2587917191U, 3461701226U, 325467495U, 913121727U, 3043180009U, 2263608261U,
			2024826929U, 1390204986U, 2473414728U, 1785717795U, 135690577U, 1354693385U, 1733800052U, 1226215657U, 2368834452U, 2563665327U,
			2626834337U, 3779533705U, 1881131452U, 1004484765U, 912409168U, 2294979069U, 2055377167U, 917880789U, 1987739748U, 2202770186U,
			176360769U, 2957467722U, 2713432356U, 2752176946U, 3817674687U, 2870549119U, 2442134017U, 2198663678U, 2328152910U, 989022210U,
			3524169890U, 1930227121U, 1102873411U, 205810614U, 2772458253U, 695550068U, 1027030059U, 2257296735U, 1846235635U, 412605517U,
			3453542722U, 2217446661U, 1079621242U, 1483772120U, 909012783U, 1858439109U, 3162706891U, 1932850221U, 1350381684U, 382486220U,
			1867612717U, 2636880002U, 1626302375U, 1492710189U, 3432620549U, 3792468903U, 1965424689U, 3325681072U, 816409583U, 520160340U,
			702224675U, 1408141282U, 2673694004U, 2290333906U, 2895011454U, 3868664542U, 3105021853U, 4258608718U, 361668123U, 1895626195U,
			3446139529U, 3479017840U, 193154577U, 1507426965U, 3345138157U, 3761409371U, 2481017905U, 2340295449U, 2667217976U, 1329021266U,
			2567362927U, 3394361766U, 866984883U, 101317425U, 2617574940U, 1439584987U, 2961037079U, 1318721774U, 407586403U, 4220036517U,
			2841713038U, 3219224988U, 3897701837U, 3888395077U, 678710108U, 3203205186U, 4086161826U, 2686941753U, 3749368151U, 53860371U,
			1474952063U, 113356879U, 709594372U, 533691761U, 3838058163U, 3145374540U, 1477788944U, 3687532055U, 3240531711U, 1630349101U,
			361691611U, 591363654U, 2825366956U, 1459100062U, 74814835U, 3738522282U, 1971656191U, 3992810591U, 1038249346U, 2347767533U,
			3368491665U, 1856742898U, 1813494390U, 2550834794U, 588702154U, 2694849421U, 3270305349U, 2261189531U, 3983453163U, 2143151596U,
			2836643528U, 3839955212U, 2263301121U, 3804086022U, 891207422U, 918014200U, 457923052U, 462081822U, 3697462562U, 3015688844U,
			361427216U, 3825865734U, 229623106U, 3290059650U, 4179010582U, 1412096774U, 1314845440U, 1686133734U, 2703682634U, 3568263128U,
			3461188521U, 943078801U, 3229806476U, 2789248244U, 101999804U, 1849502374U, 1894458693U, 499942226U, 1643562389U, 4129302126U,
			1807078384U, 3685087492U, 3838809614U, 2532562234U, 4083353564U, 1701184339U, 479750029U, 2808038852U, 2637945975U, 786637655U,
			1530496523U, 1915827273U, 177571242U, 1684064275U, 1306501187U, 1785968158U, 1502434725U, 1873651867U, 4161733127U, 3914945431U,
			3605463353U, 1845365945U, 591939910U, 392530699U, 2980654948U, 3411760075U, 3575404409U, 4136667496U, 4286513632U, 404483159U,
			1518296099U, 1327363510U, 3181108480U, 2242065169U, 575340721U, 2427025693U, 2663754792U, 895502127U, 2752433736U, 2915676887U,
			3835532710U, 1402694243U, 4063529392U, 1846529776U, 2936172453U, 1737874409U, 25562842U, 697518448U, 3563426723U, 2041431112U,
			2843015152U, 4225004664U, 3248570894U, 940417313U, 909212992U, 4086031357U, 3713889998U, 2449341638U, 231041265U, 3534723070U,
			522588556U, 3817889019U, 4219880102U, 4213335840U, 658656039U, 1460763153U, 1239995718U, 1486687149U, 77492692U, 2323200533U,
			3132982684U, 650419276U, 4125066408U, 3017421733U, 2457257647U, 2184166865U, 4293573422U, 3757467534U, 1838490501U, 1146415000U,
			366828458U, 1433380418U, 1996777661U, 290392088U, 2735150055U, 734190053U, 3738703536U, 3405254207U, 76811257U, 921214299U,
			1033252300U, 1548220884U, 1206747598U, 1897394116U, 1102143629U, 2719861193U, 3992184812U, 3681344555U, 1771706736U, 245009619U,
			2624675829U, 1020564581U, 2303571288U, 3395498378U, 1196719686U, 3563743116U, 2378839895U, 2553118800U, 1805244681U, 2672249739U,
			2921090618U, 3009625735U, 3909210539U, 4254565485U, 787053248U, 2320584530U, 3786408395U, 1359864686U, 2285032896U, 3799564370U,
			281707904U, 4244465063U, 2142569029U, 3744055828U, 2931992498U, 1120538008U, 3065356809U, 644669844U, 1108346846U, 3924071534U,
			2798702457U, 2253206045U, 542604476U, 2210265161U, 3778373085U, 37256212U, 790494531U, 2240142083U, 1549231345U, 4265741645U,
			3170042173U, 3987786181U, 2696946655U, 820173393U, 1233191931U, 49773960U, 4266239946U, 788924776U, 2520723961U, 4031850134U,
			1426643848U, 2986164786U, 3900632736U, 2149725217U, 1581321617U, 2061065055U, 2125695912U, 2301657080U, 1840398375U, 196206956U,
			3500265823U, 591955068U, 2344653903U, 1792468121U, 3159956460U, 287183447U, 1334680778U, 35834487U, 252940389U, 843240060U,
			2333859724U, 2799439685U, 3631819114U, 1293756046U, 2427355161U, 2658457129U, 2128039907U, 3195586333U, 816737986U, 3122812067U,
			1388113102U, 4150520389U, 3759602861U, 2212897757U, 2085188801U, 2734270521U, 3147203277U, 2583719987U, 3631451969U, 1671211547U,
			1067769546U, 1460638715U, 703509915U, 950185771U, 1770638658U, 3431997316U, 1400137082U, 2989540995U, 1628711658U, 1091630805U,
			164278576U, 562282228U, 1374861065U, 716887563U, 2239218200U, 1562875087U, 3166610156U, 384493963U, 689676540U, 2903785097U,
			3549656451U, 829641977U, 2680123923U, 4233263393U, 113087411U, 441559197U, 195476140U, 1947575008U, 2987026400U, 87698015U,
			1817218957U, 2244566664U, 202857452U, 1869261015U, 2176467747U, 260098863U, 1223529555U, 2073975480U, 977693452U, 223790102U,
			2584620619U, 2011288002U, 3333683471U, 2446875203U, 3000988324U, 4121986794U, 3493141415U, 1998420352U, 4007885270U, 1389442920U,
			441851565U, 1789645384U, 3169671906U, 1499267059U, 3129342546U, 3119878018U, 2775566618U, 1067564854U, 816081305U, 4102507624U,
			2941957339U, 3394583270U, 2926865126U, 3351635776U, 4083511679U, 1467946014U, 1794941605U, 363898448U, 2756155239U, 2991919625U,
			456456550U, 650197471U, 3838581787U, 92600433U, 3993615878U, 2452102428U, 2574080082U, 494942288U, 2643743982U, 329129833U,
			3757034445U, 22884192U, 2776310385U, 2090321258U, 3718113288U, 2917424887U, 2644271611U, 3828215057U, 1975274396U, 3243843366U,
			444667110U, 2726466471U, 107845953U, 3876870562U, 1098327597U, 2005522864U, 1035350761U, 3537762573U, 4002057163U, 3456731934U,
			4247194539U, 2101362190U, 1402716846U, 1236960218U, 1025824498U, 2652207807U, 2431559359U, 2362972898U, 3943444441U, 1208473636U,
			2670430194U, 2377923040U, 1733534051U, 352085793U, 755794581U, 3218549379U, 197814364U, 2307899728U, 993242611U, 1814738114U,
			1238630565U, 1918875958U, 3329912064U, 3880038190U, 2925353850U, 247755901U, 1178011122U, 3925489175U, 76548015U, 1984296840U,
			2056071280U, 4112903510U, 2902425522U, 3773058967U, 1370196944U, 3358598375U, 3808627037U, 1949095992U, 1183475840U, 3692164832U,
			3441119550U, 1957056740U, 129349440U, 2848309286U, 3364513176U, 3112746823U, 1175098883U, 1592555012U, 2779466716U, 742816669U,
			1849625114U, 1978463276U, 4119465212U, 4261503546U, 1435780402U, 2705275433U, 871784398U, 837710004U, 3571694661U, 2445537518U,
			2868075385U, 1090198168U, 3669626180U, 400259189U, 397773202U, 370868991U, 481638783U, 872541490U, 2278855330U, 3817257115U,
			3894593784U, 3258603532U, 2466485761U, 3743685047U, 3195441825U, 383853694U, 256240461U, 3953709417U, 1768668088U, 2362612718U,
			2608169539U, 3003813955U, 1564533305U, 1166787717U, 1839187641U, 548686509U, 2310591154U, 1591096671U, 2807249121U, 1373019377U,
			1226875298U, 4160548079U, 347221589U, 3748377699U, 2333069552U, 1642319610U, 3758869857U, 1648882784U, 3544951931U, 2734794853U,
			538314255U, 2548197815U, 1979469333U, 2110727160U, 624510905U, 80555158U, 67141509U, 87905839U, 2127261755U, 2229132915U,
			260866594U, 464489843U, 1226508151U, 3890204218U, 4028278843U, 2060826008U, 1165797049U, 28096244U, 3996206393U, 482386425U,
			3346937429U, 768083827U, 1347024245U, 3091603957U, 2633647332U, 966375244U, 345352024U, 2426380635U, 2700931647U, 1594848435U,
			2137165575U, 1572296463U, 1989672600U, 802764665U, 2074651515U, 1679472656U, 4097646199U, 3672036508U, 3718741331U, 3818225921U,
			1297839025U, 1701087544U, 537293101U, 1522975500U, 3818202608U, 2639782061U, 2120138860U, 2212080638U, 2317652155U, 1947234945U,
			3308169058U, 3685409150U, 1671069125U, 666904195U, 3819960901U, 2950669514U, 3275496695U, 2720304740U, 4055124697U, 233252212U,
			3124541164U, 427911858U, 2492831240U, 2518966933U, 4164076442U, 50592399U, 2110128963U, 155451915U, 2846605411U, 2896950716U,
			2550289225U, 3122168141U, 3401302037U, 656386402U, 815872823U, 3969761093U, 2880928615U, 3786032557U, 4256825496U, 2319705979U,
			2828684948U, 3442675085U, 4059028091U, 206104746U, 3835987659U, 1154184528U, 1937903323U, 3502482050U, 3951778757U, 1169572583U,
			1581501276U, 2747172554U, 2252237461U, 886333665U, 616147668U, 1858292160U, 3369190324U, 3283292287U, 1502812098U, 2034699685U,
			2937848038U, 1907101961U, 3401057468U, 1042589968U, 837064768U, 1704384542U, 1519227056U, 208422512U, 698583362U, 3911613995U,
			2841133204U, 1071326058U, 772333291U, 3987481372U, 346439359U, 2961760450U, 1105925060U, 4079707018U, 3506984574U, 531104200U,
			2783588053U, 2456094057U, 3777116272U, 3656007774U, 892428501U, 3049363874U, 1823199318U, 1454500447U, 1783748334U, 1683602120U,
			597030569U, 4288476932U, 2629210327U, 467697798U, 879407686U, 2700945525U, 441399968U, 54771158U, 2713156069U, 284493208U,
			1769728829U, 3423925852U, 3757243011U, 3701481510U, 3792995896U, 290131896U, 4166200698U, 2806135947U, 2032559976U, 3172533833U,
			2193743707U, 2386265765U, 3336104396U, 2463309821U, 64059632U, 2840397749U, 1165546402U, 2127291102U, 1165657002U, 876540892U,
			3197032550U, 1743537008U, 1865339650U, 3543817109U, 4116917046U, 4237082049U, 4046461258U, 310334149U, 2982592966U, 3490958523U,
			4186155686U, 2911040341U, 666553684U, 97845436U, 2584604862U, 3476605543U, 1331270606U, 3354399891U, 2875595185U, 2395104384U,
			604559558U, 3407913349U, 1330783756U, 1222958701U, 1983943459U, 2906352526U, 1207542675U, 3398035348U, 2945753959U, 583888938U,
			659133992U, 2468853576U, 3814427718U, 3066681380U, 939361343U, 716096564U, 2939369852U, 4154765437U, 3327753213U, 20688782U,
			1172087098U, 3797701523U, 1464990843U, 839869632U, 2764026326U, 2936552566U, 2291846347U, 4041608297U, 2446288814U, 4190613033U,
			2194858053U, 940652106U, 214614696U, 1722727770U, 433979479U, 1280138137U, 2613062789U, 875890533U, 527149472U, 637536477U,
			4131114222U, 3837655158U, 878457318U, 3207838033U, 3456495256U, 3701535690U, 4272242754U, 2872360569U, 1888079964U, 1104956081U,
			3294089878U, 3708017993U, 2317593396U, 2016421625U, 1777366048U, 3980509523U, 3565411077U, 3165287322U, 3236270580U, 2546486749U,
			3801200814U, 950155334U, 2182988023U, 3845537111U, 3890980421U, 1394527393U, 2989384433U, 3037283083U, 204721445U, 3478043855U,
			2857163679U, 3181655976U, 4160904832U, 291949044U, 586234767U, 3563895947U, 2817665883U, 3565227508U, 2901178764U, 1534940058U,
			3509354879U, 1042757733U, 1945031035U, 576354053U, 3241049710U, 1381411727U, 1298518372U, 2283980557U, 2214495778U, 3891508740U,
			3882139680U, 3891103405U, 1916292152U, 2855607966U, 2302316115U, 895609420U, 1384415398U, 2069211823U, 2894244614U, 1433581891U,
			995282692U, 2423240352U, 2097974751U, 4286598598U, 929525447U, 3067037788U, 784885429U, 511370707U, 3807461620U, 3101341742U,
			486772597U, 34589450U, 4092490470U, 2792438074U, 3532385337U, 3228011533U, 3830143800U, 807265405U, 2314351516U, 2140183980U,
			2102188981U, 298032779U, 1502692227U, 986080481U, 3424195387U, 2512134753U, 490019228U, 2496775435U, 2801392116U, 3562599505U,
			1960422720U, 1062554427U, 2260116987U, 1181114318U, 2644780794U, 739381659U, 797814074U, 1850151424U, 887204193U, 1529396818U,
			3337795333U, 2500495090U, 2648266U, 3344470129U, 3299811321U, 1395815049U, 1577877318U, 4012142015U, 149741404U, 2043710259U,
			96704537U, 906345930U, 1463680637U, 1873131789U, 4005725482U, 3277684968U, 2620043937U, 2365260135U, 555855940U, 276309949U,
			477817531U, 103421482U, 1136918702U, 2207340571U, 2481508072U, 521671593U, 2562005225U, 87220973U, 3903354510U, 1995377506U,
			2255898770U, 1966917926U, 3267862520U, 3489508524U, 706226580U, 3520194349U, 3006460344U, 3768609143U, 15741096U, 2914545840U,
			941681899U, 4192901497U, 678779764U, 2075716871U, 211201837U, 24643377U, 689762987U, 915731352U, 2287380511U, 2897552516U,
			413460803U, 3111404478U, 1113800207U, 2393391701U, 850642920U, 2101388305U, 604553546U, 2282625030U, 3771319432U, 10762779U,
			1005090601U, 2787659406U, 3426393245U, 1712366032U, 3864645920U, 282346586U, 1965824625U, 4237714888U, 1415785652U, 3312894697U,
			2698675438U, 4122077136U, 456977198U, 2424832336U, 3135558786U, 1324602940U, 3756376088U, 467751504U, 1240171838U, 483764220U,
			2273554065U, 1212560432U, 1940956034U, 357439762U, 2263577087U, 1575338117U, 1710811155U, 2401219582U, 575051208U, 2090970025U,
			2484794240U, 2181888787U, 2384616908U, 4182859455U, 2649146023U, 3980117583U, 1649558359U, 3983991056U, 8351191U, 2639648339U,
			3502444781U, 370447373U, 1845367800U, 1513663543U, 2464350802U, 694212523U, 2701436331U, 854002548U, 3028799373U, 380608325U,
			828993620U, 3892462442U, 171649325U, 3957779296U, 1386185773U, 2420882464U, 2102550366U, 1814399146U, 969476719U, 1812738134U,
			1528861314U, 2378800581U, 3213084805U, 2336312563U, 1925125086U, 143519209U, 759073444U, 2928617254U, 1412883374U, 126070982U,
			2095410892U, 3241692905U, 3506580237U, 1647541150U, 1975991972U, 3573815330U, 3502980658U, 2735457559U, 3344648498U, 1946410957U,
			3064729621U, 2670492123U, 1788604408U, 3136820148U, 1408248785U, 3310130804U, 822735699U, 3107258324U, 731597363U, 603093937U,
			2286770448U, 2431355388U, 3202674822U, 2704958590U, 17743944U, 1688208938U, 1864854677U, 2110124071U, 342114999U, 3645042478U,
			3155648915U, 3821169597U, 4100652877U, 105569563U, 3557390564U, 803137430U, 138911911U, 3834421954U, 3949078799U, 2572567822U,
			697185874U, 3835949310U, 237407863U, 650635758U, 437938462U, 1101202696U, 2129737405U, 770750795U, 3858870359U, 236447313U,
			2724104110U, 3043681481U, 2968969221U, 3237608878U, 1453116899U, 2895520165U, 2116767142U, 2207392478U, 2867091188U, 3724835765U,
			810368553U, 3186385418U, 3799423634U, 2611282572U, 2740051800U, 3694008095U, 979002998U, 951238729U, 1031221061U, 555500996U,
			1758700426U, 2676458320U, 1982774076U, 2884211107U, 1706092228U, 1827707947U, 303252198U, 3791889521U, 2550832684U, 2088194465U,
			2931408550U, 27211010U, 2485543310U, 2375418104U, 1791042039U, 2667258565U, 2760519950U, 100068457U, 2722238730U, 2015299268U,
			2915504626U, 2053139830U, 2436147467U, 3275028422U, 175679135U, 3338087331U, 3801378189U, 3779806607U, 1092137694U, 1107849857U,
			2554299537U, 542497618U, 3504732122U, 2208997706U, 3762458871U, 3238972094U, 2964689468U, 3547373138U, 3877303375U, 227673217U,
			2209276757U, 1857089206U, 4218569631U, 452167140U, 2541816341U, 3429440549U, 3762451641U, 1141050789U, 99449601U, 1526550704U,
			3281620555U, 3690612181U, 2447704770U, 898369775U, 2669921790U, 3108813173U, 198520741U, 2482297265U, 3363536970U, 110570020U,
			2409416799U, 313726674U, 542638219U, 1225773020U, 3339301127U, 2625540431U, 2943748991U, 600269295U, 2472846188U, 2233985325U,
			2629690185U, 3356386518U, 2491966865U, 3521602461U, 1840762232U, 2088492639U, 1618785984U, 3215308782U, 2933966340U, 3884207468U,
			2581812841U, 3985158750U, 2395367151U, 2788574917U, 570988686U, 286931411U, 1579779077U, 3462958285U, 2573296863U, 2446043445U,
			1830433802U, 3466829325U, 3777482793U, 1786848922U, 1538141348U, 3970505957U, 949069755U, 110130882U, 1291728770U, 3647650858U,
			3739947169U, 1506787035U, 2419878637U, 918448886U, 1637546468U, 2074496043U, 1185872411U, 3136223353U, 2412091972U, 3424665671U,
			3695267915U, 2281837963U, 959879160U, 3363852694U, 1638748862U, 1347552106U, 1044920017U, 2989652980U, 594743405U, 4016629510U,
			4080637922U, 4066908699U, 3898236750U, 977035404U, 4144559000U, 1884386943U, 3022341379U, 3160718391U, 932294660U, 1911827506U,
			3973067372U, 3350739522U, 2499411311U, 4087106451U, 24831850U, 1295012773U, 1899249134U, 1402476333U, 1945528947U, 1157702835U,
			1389453253U, 2383008692U, 3697429604U, 58336942U, 2703956567U, 120553297U, 2725724728U, 2838825109U, 3549702192U, 862019751U,
			1098939829U, 1691059194U, 4154438837U, 3623902702U, 547932825U, 3623771917U, 1623711515U, 2277283122U, 3758969346U, 3312725852U,
			840286523U, 1203706588U, 471534478U, 31912460U, 149433966U, 3895619517U, 4131706820U, 1421502206U, 3847049989U, 2035845062U,
			1624432068U, 2760992009U, 1030263007U, 3653850687U, 368550383U, 289974547U, 1972231191U, 3872922650U, 982164235U, 3669320621U,
			2254853874U, 618323551U, 2554579012U, 2215216495U, 1116830195U, 1622627566U, 2443903224U, 814752555U, 3966686778U, 3154342633U,
			3657791724U, 336271057U, 2878977530U, 1600760123U, 1594692992U, 3186434544U, 2199048307U, 1942694226U, 2911064272U, 3735042349U,
			417538212U, 1595570548U, 2703193191U, 2263310763U, 1710962790U, 2741637223U, 1695617596U, 852297397U, 1999701752U, 619757966U,
			4196142902U, 3190398803U, 2524026462U, 2406595928U, 475603478U, 344814314U, 3805827726U, 4084291615U, 2120745930U, 1222202419U,
			616868851U, 2087950551U, 3629429137U, 2542450282U, 25987098U, 2664977916U, 3834951047U, 1409514644U, 297063263U, 3508607004U,
			1143722780U, 3709637264U, 805477716U, 3932221358U, 1503728464U, 2062989155U, 272856390U, 539013512U, 2325796132U, 1425267043U,
			1467567718U, 2679336022U, 3068056016U, 2332280502U, 2007996037U, 2430659727U, 3955789333U, 2321413642U, 1124317849U, 4265240158U,
			1509986393U, 3002687299U, 703615463U, 1350853294U, 1103750173U, 4069366931U, 4131861044U, 2092083U, 2809687844U, 2925050675U,
			98983618U, 2493322106U, 900284997U, 2718437131U, 2622895865U, 2661455084U, 2673750607U, 3413141857U, 394517142U, 3909566463U,
			3153963335U, 1726936964U, 2459778759U, 2460468916U, 4093448406U, 3761725483U, 1422591669U, 3347463205U, 3381377933U, 3291022088U,
			3931618687U, 3989487669U, 3061373634U, 936609459U, 1999981355U, 758513835U, 2901279106U, 4147148539U, 360241191U, 281953714U,
			2932498406U, 4193444189U, 2260340014U, 3627320607U, 1493858906U, 2671917549U, 3385729537U, 4060128526U, 3492070073U, 2389815245U,
			4185871263U, 3785645958U, 209857111U, 1009216940U, 4194796238U, 3027369381U, 2037658025U, 3416986181U, 4256762202U, 3831336810U,
			2505408966U, 725299358U, 1557346127U, 3935707839U, 1063491970U, 1340268815U, 297735618U, 856227796U, 1943693440U, 2830860869U,
			2885266727U, 1440795904U, 3180267365U, 3219133520U, 3880434389U, 76681741U, 2206406422U, 1355257254U, 3684407231U, 4008432316U,
			3342128146U, 727445683U, 3130614718U, 339985546U, 2319951751U, 2824673519U, 2915425138U, 1799962862U, 2532341203U, 342513850U,
			2124150856U, 3808267771U, 794617181U, 1548156174U, 1845616164U, 3071235865U, 3832496852U, 3653249090U, 2681367103U, 4025769621U,
			1569123989U, 3581760616U, 1678914002U, 3943753467U, 4075062244U, 2139971691U, 2910256064U, 2809872742U, 1649040035U, 2510804423U,
			30133173U, 3288945756U, 811309456U, 2730372683U, 3920703992U, 1435826242U, 3575796508U, 3317223426U, 779972741U, 336682639U,
			2274731534U, 1968016078U, 3357812332U, 2279284128U, 1337940054U, 2663279479U, 3449558050U, 522033954U, 82369135U, 1939365254U,
			3417328723U, 1997825421U, 261552580U, 3426894776U, 1890606282U, 1067823110U, 3970665417U, 487218143U, 2407903012U, 766174713U,
			2750763878U, 683776154U, 1824011455U, 2630415333U, 2022846478U, 2601209993U, 123217818U, 1276477920U, 3965737669U, 873950288U,
			1007668233U, 2511917392U, 2959589555U, 4286421538U, 3532448063U, 1388628883U, 2997049211U, 1284207691U, 604129316U, 2774542470U,
			1128241862U, 923532812U, 2985167754U, 3741558015U, 3761451242U, 631476082U, 4219955253U, 3613138628U, 834892841U, 3810390621U,
			91294921U, 807904974U, 3426778508U, 297877420U, 2770217281U, 288534899U, 979151862U, 734388497U, 2538835991U, 1237340661U,
			2761760051U, 3051503243U, 3399999460U, 1190361795U, 445623553U, 4290957468U, 2038008994U, 1115091063U, 754613056U, 1058593730U,
			3973249779U, 3862028827U, 2711399561U, 2052482254U, 1330909531U, 2387922633U, 2049194909U, 3051159913U, 1005687511U, 1775359302U,
			2893104747U, 1729169019U, 701136469U, 3161517894U, 229530345U, 1469433513U, 2234581617U, 4876068U, 2217068151U, 2820993900U,
			3354447571U, 1820353698U, 3662891925U, 1936794067U, 3963911710U, 1359015350U, 1485597515U, 2411027419U, 3897496978U, 2993844869U,
			2360700877U, 3460465918U, 3674979637U, 1325101262U, 354444671U, 3903812498U, 2343020132U, 2328729380U, 4263051806U, 3697030541U,
			3877245606U, 4215951138U, 3942015752U, 2067912610U, 3324607019U, 2838135565U, 2084896748U, 4146582195U, 2688885980U, 2339748741U,
			3406712237U, 3283309000U, 1571694693U, 2596733847U, 2718748462U, 4207169075U, 2610040249U, 3769124299U, 2929332118U, "Not showing all elements because this array is too big (135664 elements)"
		};
		uint[] array2 = new uint[16];
		uint num2 = 3880390459U;
		for (int i = 0; i < 16; i++)
		{
			num2 ^= num2 >> 13;
			num2 ^= num2 << 25;
			num2 ^= num2 >> 27;
			array2[i] = num2;
		}
		int num3 = 0;
		int num4 = 0;
		uint[] array3 = new uint[16];
		byte[] array4 = new byte[num * 4U];
		while ((long)num3 < (long)((ulong)num))
		{
			for (int j = 0; j < 16; j++)
			{
				array3[j] = array[num3 + j];
			}
			uint num5 = array3[5] >> 3;
			array3[5] = array3[5] << 29;
			array3[5] = array3[5] | num5;
			array3[2] = array3[2] ^ array2[2];
			array3[14] = array3[14] ^ array2[14];
			num5 = array3[10] >> 31;
			uint num6 = array3[5] * 41U;
			array3[10] = array3[10] << 1;
			array3[10] = array3[10] | num5;
			num5 = array3[14] & 2613440770U;
			uint num7 = array3[5] * 51U;
			array3[14] = array3[14] & 1681526525U;
			num5 *= 596882881U;
			array3[14] = array3[14] | (array3[6] & 2613440770U);
			array3[6] = array3[6] & 1681526525U;
			uint num8 = array3[5] * 54U;
			array3[6] = array3[6] | (num5 * 970545729U);
			num5 = array3[1] << 2;
			array3[1] = array3[1] >> 30;
			array3[1] = array3[1] | num5;
			num8 += array3[1] * 187U;
			array3[0] = array3[0] ^ array2[0];
			num8 += array3[6] * 57U;
			num6 += array3[1] << 4;
			num5 = array3[5] << 4;
			num7 += array3[1] * 176U;
			num5 += array3[1] * 55U;
			num7 += array3[6] * 52U;
			num5 += array3[6] << 4;
			array3[2] = array3[2] ^ 2492804212U;
			num5 += array3[3] * 59U;
			num6 += array3[1] << 7;
			array3[4] = array3[4] ^ array2[4];
			num7 += array3[3] * 189U;
			array3[4] = array3[4] ^ 3792721218U;
			array3[2] = array3[2] ^ 321019168U;
			array3[1] = num7;
			num7 = array3[11] * 21U;
			num8 += array3[3] * 202U;
			num6 += array3[6] * 49U;
			array3[5] = num5;
			num6 += array3[3] * 159U;
			array3[5] = array3[5] ^ ~array3[1];
			num5 = array3[0] * 2861956615U;
			array3[3] = num6;
			array3[0] = array3[8];
			array3[0] = array3[0] ^ array3[1];
			num7 += array3[10] * 35U;
			array3[6] = num8;
			array3[8] = num5 * 2863861687U;
			num8 = array3[11] << 1;
			num6 = array3[11] * 13U;
			array3[6] = array3[6] ^ 1654402140U;
			num5 = array3[11] << 4;
			num6 += array3[10] << 4;
			num8 += array3[11] << 2;
			num8 += array3[10] << 2;
			num5 += array3[10] << 3;
			array3[8] = array3[8] * 3338561163U;
			num8 += array3[10];
			num7 += array3[7] * 202U;
			num6 += array3[7] * 104U;
			num8 += array3[7] * 39U;
			num8 += array3[9] * 35U;
			num5 += array3[10] << 4;
			num6 += array3[9] << 5;
			num5 += array3[7] * 145U;
			array3[11] = num8;
			num6 += array3[9] << 6;
			num7 += array3[9] * 190U;
			num8 = array3[15] & 109080244U;
			num8 *= 250878915U;
			array3[2] = array3[2] - array3[5];
			array3[15] = array3[15] & 4185887051U;
			num5 += array3[9] << 3;
			array3[15] = array3[15] | (array3[14] & 109080244U);
			num5 += array3[9] << 7;
			array3[1] = array3[1] ^ 3673311805U;
			array3[7] = num7;
			array3[9] = num5;
			array3[14] = array3[14] & 4185887051U;
			num7 = array3[15] & 1938127725U;
			num5 = array3[12] * 4224236877U;
			array3[12] = array3[13];
			array3[12] = array3[12] ^ array2[12];
			array3[10] = num6;
			array3[15] = array3[15] & 2356839570U;
			array3[14] = array3[14] | (num8 * 3640077547U);
			num7 *= 988515685U;
			num8 = array3[3] >> 14;
			array3[3] = array3[3] << 18;
			array3[3] = array3[3] | num8;
			num8 = array3[7] & 3204689386U;
			array3[15] = array3[15] | (array3[12] & 1938127725U);
			array3[3] = array3[3] - array3[11];
			array3[13] = num5 * 949273477U;
			array3[7] = array3[7] & 1090277909U;
			array3[11] = array3[11] ^ array2[11];
			array3[9] = array3[9] ^ array2[9];
			array3[5] = array3[5] ^ array2[5];
			array3[12] = array3[12] & 2356839570U;
			array3[14] = array3[14] * 298940483U;
			array3[12] = array3[12] | (num7 * 3645561965U);
			array3[7] = array3[7] | (array3[9] & 3204689386U);
			array3[7] = array3[7] ^ array2[7];
			array3[9] = array3[9] & 1090277909U;
			num8 *= 3411831039U;
			num5 = array3[2] >> 9;
			array3[10] = array3[10] ^ array2[10];
			num7 = array3[7] << 2;
			array3[2] = array3[2] << 23;
			array3[2] = array3[2] | num5;
			num6 = array3[12] * 2139113565U;
			array3[12] = array3[0];
			array3[0] = num6 * 581815285U;
			array3[10] = array3[10] ^ array3[4];
			array3[9] = array3[9] | (num8 * 2559743743U);
			num5 = array3[7] << 4;
			num5 += array3[9] << 3;
			array3[12] = array3[12] - array3[0];
			num6 = array3[11] >> 27;
			array3[11] = array3[11] << 5;
			array3[11] = array3[11] | num6;
			num7 += array3[7];
			num5 += array3[9] << 5;
			num8 = array3[7] << 1;
			num7 += array3[9] * 13U;
			num5 += array3[14] * 76U;
			num8 += array3[7] << 2;
			array3[15] = array3[15] - 2391507842U;
			array3[8] = array3[8] - array3[3];
			array3[1] = array3[1] ^ array2[1];
			num8 += array3[9] * 15U;
			num8 += array3[14] * 30U;
			num6 = array3[7] * 7U;
			array3[6] = array3[6] * 524409161U;
			num5 += array3[10] * 165U;
			array3[6] = array3[6] ^ array2[6];
			num8 += array3[10] * 67U;
			num7 += array3[14] * 25U;
			num6 += array3[9] * 19U;
			num6 += array3[14] * 38U;
			num7 += array3[10] * 54U;
			array3[13] = array3[13] ^ 3319585423U;
			array3[13] = array3[13] ^ array2[13];
			num6 += array3[10] * 83U;
			array3[10] = num8;
			num8 = array3[4] << 18;
			array3[4] = array3[4] >> 14;
			array3[14] = num6;
			array3[4] = array3[4] | num8;
			num8 = array3[10] & 1174942923U;
			array3[3] = array3[3] ^ array2[3];
			array3[7] = num7;
			num8 *= 2519180501U;
			array3[10] = array3[10] & 3120024372U;
			array3[10] = array3[10] | (array3[8] & 1174942923U);
			array3[8] = array3[8] & 3120024372U;
			array3[9] = num5;
			array3[8] = array3[8] | (num8 * 1646556285U);
			num6 = array3[8] << 3;
			num8 = array3[8] << 2;
			num7 = array3[8] << 1;
			num7 += array3[8];
			num8 += array3[8] << 3;
			num7 += array3[3] << 2;
			array3[13] = array3[13] * 3618978285U;
			num8 += array3[3] * 42U;
			array3[0] = array3[0] - array3[9];
			num5 = array3[8] << 2;
			num6 += array3[3] * 29U;
			num6 += array3[12] * 90U;
			num5 += array3[3] << 1;
			array3[15] = array3[15] ^ array2[15];
			num8 += array3[12] * 131U;
			num6 += array3[14] * 50U;
			num5 += array3[3] << 2;
			array3[4] = array3[4] ^ array3[15];
			num7 += array3[3] << 3;
			num5 += array3[12] * 19U;
			array3[5] = array3[5] - 3127413893U;
			num8 += array3[14] * 74U;
			num7 += array3[12] * 37U;
			num5 += array3[14] * 13U;
			array3[8] = num5;
			array3[6] = array3[6] ^ 1313978796U;
			num7 += array3[14] << 2;
			num5 = array3[10] << 6;
			array3[1] = array3[1] ^ ~array3[7];
			array3[10] = array3[10] >> 26;
			num7 += array3[14] << 4;
			array3[12] = num6;
			array3[3] = num7;
			array3[10] = array3[10] | num5;
			array3[14] = num8;
			num6 = array3[0] << 5;
			array3[6] = array3[6] * 2240549415U;
			num8 = array3[0] << 1;
			num7 = array3[0] * 14U;
			array3[5] = array3[5] ^ ~array3[13];
			num6 += array3[0];
			num7 += array3[1] * 58U;
			num5 = array3[0] << 3;
			num5 += array3[0] << 4;
			num8 += array3[0] << 3;
			num6 += array3[1] * 139U;
			num8 += array3[1] * 42U;
			num5 += array3[1] * 99U;
			num7 += array3[2] * 103U;
			num6 += array3[2] * 249U;
			num7 += array3[3] * 60U;
			array3[11] = array3[11] ^ array3[2];
			num5 += array3[2] * 177U;
			num8 += array3[2] * 75U;
			num5 += array3[3] * 106U;
			array3[2] = num7;
			num6 += array3[3] * 143U;
			num8 += array3[3] * 43U;
			array3[1] = num6;
			array3[3] = num5;
			array3[0] = num8;
			array3[8] = array3[8] ^ array2[8];
			for (int k = 0; k < 16; k++)
			{
				uint num9 = array3[k];
				array4[num4++] = (byte)num9;
				array4[num4++] = (byte)(num9 >> 8);
				array4[num4++] = (byte)(num9 >> 16);
				array4[num4++] = (byte)(num9 >> 24);
				array2[k] ^= num9;
			}
			num3 += 16;
		}
		return Decryptor.smethod_1(array4);
	}

	internal static Assembly smethod_13(object sender, ResolveEventArgs args)
	{
		if (Decryptor.assembly_0.FullName == args.Name)
		{
			return Decryptor.assembly_0;
		}
		return null;
	}

	internal static byte[] byte_0;

	internal static Decryptor.Struct4 struct4_0;

	internal static Assembly assembly_0;

	internal static Decryptor.Struct5 struct5_0;

	internal struct Struct0
	{
		internal void method_0()
		{
			this.uint_0 = 1024U;
		}

		internal uint method_1(Decryptor.Class0 rangeDecoder)
		{
			uint num = (rangeDecoder.uint_1 >> 11) * this.uint_0;
			if (rangeDecoder.uint_0 < num)
			{
				rangeDecoder.uint_1 = num;
				this.uint_0 += 2048U - this.uint_0 >> 5;
				if (rangeDecoder.uint_1 < 16777216U)
				{
					rangeDecoder.uint_0 = (rangeDecoder.uint_0 << 8) | (uint)((byte)rangeDecoder.stream_0.ReadByte());
					rangeDecoder.uint_1 <<= 8;
				}
				return 0U;
			}
			rangeDecoder.uint_1 -= num;
			rangeDecoder.uint_0 -= num;
			this.uint_0 -= this.uint_0 >> 5;
			if (rangeDecoder.uint_1 < 16777216U)
			{
				rangeDecoder.uint_0 = (rangeDecoder.uint_0 << 8) | (uint)((byte)rangeDecoder.stream_0.ReadByte());
				rangeDecoder.uint_1 <<= 8;
			}
			return 1U;
		}

		internal uint uint_0;
	}

	internal struct Struct1
	{
		internal Struct1(int numBitLevels)
		{
			this.int_0 = numBitLevels;
			this.struct0_0 = new Decryptor.Struct0[1 << numBitLevels];
		}

		internal void method_0()
		{
			uint num = 1U;
			while ((ulong)num < (ulong)(1L << (this.int_0 & 31)))
			{
				this.struct0_0[(int)num].method_0();
				num += 1U;
			}
		}

		internal uint method_1(Decryptor.Class0 rangeDecoder)
		{
			uint num = 1U;
			for (int i = this.int_0; i > 0; i--)
			{
				num = (num << 1) + this.struct0_0[(int)num].method_1(rangeDecoder);
			}
			return num - (1U << this.int_0);
		}

		internal uint method_2(Decryptor.Class0 rangeDecoder)
		{
			uint num = 1U;
			uint num2 = 0U;
			for (int i = 0; i < this.int_0; i++)
			{
				uint num3 = this.struct0_0[(int)num].method_1(rangeDecoder);
				num <<= 1;
				num += num3;
				num2 |= num3 << i;
			}
			return num2;
		}

		internal static uint smethod_0(Decryptor.Struct0[] Models, uint startIndex, Decryptor.Class0 rangeDecoder, int NumBitLevels)
		{
			uint num = 1U;
			uint num2 = 0U;
			for (int i = 0; i < NumBitLevels; i++)
			{
				uint num3 = Models[(int)(startIndex + num)].method_1(rangeDecoder);
				num <<= 1;
				num += num3;
				num2 |= num3 << i;
			}
			return num2;
		}

		internal readonly Decryptor.Struct0[] struct0_0;

		internal readonly int int_0;
	}

	internal class Class0
	{
		internal void method_0(Stream stream)
		{
			this.stream_0 = stream;
			this.uint_0 = 0U;
			this.uint_1 = uint.MaxValue;
			for (int i = 0; i < 5; i++)
			{
				this.uint_0 = (this.uint_0 << 8) | (uint)((byte)this.stream_0.ReadByte());
			}
		}

		internal void method_1()
		{
			this.stream_0 = null;
		}

		internal void method_2()
		{
			while (this.uint_1 < 16777216U)
			{
				this.uint_0 = (this.uint_0 << 8) | (uint)((byte)this.stream_0.ReadByte());
				this.uint_1 <<= 8;
			}
		}

		internal uint method_3(int numTotalBits)
		{
			uint num = this.uint_1;
			uint num2 = this.uint_0;
			uint num3 = 0U;
			for (int i = numTotalBits; i > 0; i--)
			{
				num >>= 1;
				uint num4 = num2 - num >> 31;
				num2 -= num & (num4 - 1U);
				num3 = (num3 << 1) | (1U - num4);
				if (num < 16777216U)
				{
					num2 = (num2 << 8) | (uint)((byte)this.stream_0.ReadByte());
					num <<= 8;
				}
			}
			this.uint_1 = num;
			this.uint_0 = num2;
			return num3;
		}

		internal Class0()
		{
		}

		internal uint uint_0;

		internal uint uint_1;

		internal Stream stream_0;
	}

	internal class Class1
	{
		internal Class1()
		{
			this.uint_0 = uint.MaxValue;
			int num = 0;
			while ((long)num < 4L)
			{
				this.struct1_0[num] = new Decryptor.Struct1(6);
				num++;
			}
		}

		internal void method_0(uint dictionarySize)
		{
			if (this.uint_0 != dictionarySize)
			{
				this.uint_0 = dictionarySize;
				this.uint_1 = Math.Max(this.uint_0, 1U);
				uint num = Math.Max(this.uint_1, 4096U);
				this.class4_0.method_0(num);
			}
		}

		internal void method_1(int lp, int lc)
		{
			this.class3_0.method_0(lp, lc);
		}

		internal void method_2(int pb)
		{
			uint num = 1U << pb;
			this.class2_0.method_0(num);
			this.class2_1.method_0(num);
			this.uint_2 = num - 1U;
		}

		internal void method_3(Stream inStream, Stream outStream)
		{
			this.class0_0.method_0(inStream);
			this.class4_0.method_1(outStream, this.bool_0);
			for (uint num = 0U; num < 12U; num += 1U)
			{
				for (uint num2 = 0U; num2 <= this.uint_2; num2 += 1U)
				{
					uint num3 = (num << 4) + num2;
					this.struct0_0[(int)num3].method_0();
					this.struct0_1[(int)num3].method_0();
				}
				this.struct0_2[(int)num].method_0();
				this.struct0_3[(int)num].method_0();
				this.struct0_4[(int)num].method_0();
				this.struct0_5[(int)num].method_0();
			}
			this.class3_0.method_1();
			for (uint num = 0U; num < 4U; num += 1U)
			{
				this.struct1_0[(int)num].method_0();
			}
			for (uint num = 0U; num < 114U; num += 1U)
			{
				this.struct0_6[(int)num].method_0();
			}
			this.class2_0.method_1();
			this.class2_1.method_1();
			this.struct1_1.method_0();
		}

		internal void method_4(Stream inStream, Stream outStream, long inSize, long outSize)
		{
			this.method_3(inStream, outStream);
			Decryptor.Struct3 @struct = default(Decryptor.Struct3);
			@struct.method_0();
			uint num = 0U;
			uint num2 = 0U;
			uint num3 = 0U;
			uint num4 = 0U;
			ulong num5 = 0UL;
			if (0L < outSize)
			{
				this.struct0_0[(int)((int)@struct.uint_0 << 4)].method_1(this.class0_0);
				@struct.method_1();
				byte b = this.class3_0.method_3(this.class0_0, 0U, 0);
				this.class4_0.method_5(b);
				num5 += 1UL;
			}
			while (num5 < (ulong)outSize)
			{
				uint num6 = (uint)num5 & this.uint_2;
				if (this.struct0_0[(int)((@struct.uint_0 << 4) + num6)].method_1(this.class0_0) == 0U)
				{
					byte b2 = this.class4_0.method_6(0U);
					byte b3;
					if (!@struct.method_5())
					{
						b3 = this.class3_0.method_4(this.class0_0, (uint)num5, b2, this.class4_0.method_6(num));
					}
					else
					{
						b3 = this.class3_0.method_3(this.class0_0, (uint)num5, b2);
					}
					this.class4_0.method_5(b3);
					@struct.method_1();
					num5 += 1UL;
				}
				else
				{
					uint num7;
					if (this.struct0_2[(int)@struct.uint_0].method_1(this.class0_0) != 1U)
					{
						num4 = num3;
						num3 = num2;
						num2 = num;
						num7 = 2U + this.class2_0.method_2(this.class0_0, num6);
						@struct.method_2();
						uint num8 = this.struct1_0[(int)Decryptor.Class1.smethod_0(num7)].method_1(this.class0_0);
						if (num8 < 4U)
						{
							num = num8;
						}
						else
						{
							int num9 = (int)((num8 >> 1) - 1U);
							num = (2U | (num8 & 1U)) << num9;
							if (num8 < 14U)
							{
								num += Decryptor.Struct1.smethod_0(this.struct0_6, num - num8 - 1U, this.class0_0, num9);
							}
							else
							{
								num += this.class0_0.method_3(num9 - 4) << 4;
								num += this.struct1_1.method_2(this.class0_0);
							}
						}
					}
					else
					{
						if (this.struct0_3[(int)@struct.uint_0].method_1(this.class0_0) != 0U)
						{
							uint num10;
							if (this.struct0_4[(int)@struct.uint_0].method_1(this.class0_0) == 0U)
							{
								num10 = num2;
							}
							else
							{
								if (this.struct0_5[(int)@struct.uint_0].method_1(this.class0_0) == 0U)
								{
									num10 = num3;
								}
								else
								{
									num10 = num4;
									num4 = num3;
								}
								num3 = num2;
							}
							num2 = num;
							num = num10;
						}
						else if (this.struct0_1[(int)((@struct.uint_0 << 4) + num6)].method_1(this.class0_0) == 0U)
						{
							@struct.method_4();
							this.class4_0.method_5(this.class4_0.method_6(num));
							num5 += 1UL;
							continue;
						}
						num7 = this.class2_1.method_2(this.class0_0, num6) + 2U;
						@struct.method_3();
					}
					if (((ulong)num >= num5 || num >= this.uint_1) && num == 4294967295U)
					{
						break;
					}
					this.class4_0.method_4(num, num7);
					num5 += (ulong)num7;
				}
			}
			this.class4_0.method_3();
			this.class4_0.method_2();
			this.class0_0.method_1();
		}

		internal void method_5(byte[] properties)
		{
			int num = (int)(properties[0] % 9);
			byte b = properties[0] / 9;
			int num2 = (int)(b % 5);
			int num3 = (int)(b / 5);
			uint num4 = 0U;
			for (int i = 0; i < 4; i++)
			{
				num4 += (uint)((uint)properties[1 + i] << i * 8);
			}
			this.method_0(num4);
			this.method_1(num2, num);
			this.method_2(num3);
		}

		internal static uint smethod_0(uint len)
		{
			len -= 2U;
			if (len < 4U)
			{
				return len;
			}
			return 3U;
		}

		internal readonly Decryptor.Struct0[] struct0_0 = new Decryptor.Struct0[192];

		internal readonly Decryptor.Struct0[] struct0_1 = new Decryptor.Struct0[192];

		internal readonly Decryptor.Struct0[] struct0_2 = new Decryptor.Struct0[12];

		internal readonly Decryptor.Struct0[] struct0_3 = new Decryptor.Struct0[12];

		internal readonly Decryptor.Struct0[] struct0_4 = new Decryptor.Struct0[12];

		internal readonly Decryptor.Struct0[] struct0_5 = new Decryptor.Struct0[12];

		internal readonly Decryptor.Class1.Class2 class2_0 = new Decryptor.Class1.Class2();

		internal readonly Decryptor.Class1.Class3 class3_0 = new Decryptor.Class1.Class3();

		internal readonly Decryptor.Class4 class4_0 = new Decryptor.Class4();

		internal readonly Decryptor.Struct0[] struct0_6 = new Decryptor.Struct0[114];

		internal readonly Decryptor.Struct1[] struct1_0 = new Decryptor.Struct1[4];

		internal readonly Decryptor.Class0 class0_0 = new Decryptor.Class0();

		internal readonly Decryptor.Class1.Class2 class2_1 = new Decryptor.Class1.Class2();

		internal bool bool_0;

		internal uint uint_0;

		internal uint uint_1;

		internal Decryptor.Struct1 struct1_1 = new Decryptor.Struct1(4);

		internal uint uint_2;

		internal class Class2
		{
			internal void method_0(uint numPosStates)
			{
				for (uint num = this.uint_0; num < numPosStates; num += 1U)
				{
					this.struct1_0[(int)num] = new Decryptor.Struct1(3);
					this.struct1_1[(int)num] = new Decryptor.Struct1(3);
				}
				this.uint_0 = numPosStates;
			}

			internal void method_1()
			{
				this.struct0_0.method_0();
				for (uint num = 0U; num < this.uint_0; num += 1U)
				{
					this.struct1_0[(int)num].method_0();
					this.struct1_1[(int)num].method_0();
				}
				this.struct0_1.method_0();
				this.struct1_2.method_0();
			}

			internal uint method_2(Decryptor.Class0 rangeDecoder, uint posState)
			{
				if (this.struct0_0.method_1(rangeDecoder) == 0U)
				{
					return this.struct1_0[(int)posState].method_1(rangeDecoder);
				}
				uint num = 8U;
				if (this.struct0_1.method_1(rangeDecoder) != 0U)
				{
					num += 8U;
					num += this.struct1_2.method_1(rangeDecoder);
				}
				else
				{
					num += this.struct1_1[(int)posState].method_1(rangeDecoder);
				}
				return num;
			}

			internal Class2()
			{
			}

			internal readonly Decryptor.Struct1[] struct1_0 = new Decryptor.Struct1[16];

			internal readonly Decryptor.Struct1[] struct1_1 = new Decryptor.Struct1[16];

			internal Decryptor.Struct0 struct0_0;

			internal Decryptor.Struct0 struct0_1;

			internal Decryptor.Struct1 struct1_2 = new Decryptor.Struct1(8);

			internal uint uint_0;
		}

		internal class Class3
		{
			internal void method_0(int numPosBits, int numPrevBits)
			{
				if (this.struct2_0 != null && this.int_1 == numPrevBits)
				{
					if (this.int_0 == numPosBits)
					{
						return;
					}
				}
				this.int_0 = numPosBits;
				this.uint_0 = (1U << numPosBits) - 1U;
				this.int_1 = numPrevBits;
				uint num = 1U << this.int_1 + this.int_0;
				this.struct2_0 = new Decryptor.Class1.Class3.Struct2[num];
				for (uint num2 = 0U; num2 < num; num2 += 1U)
				{
					this.struct2_0[(int)num2].method_0();
				}
			}

			internal void method_1()
			{
				uint num = 1U << this.int_1 + this.int_0;
				for (uint num2 = 0U; num2 < num; num2 += 1U)
				{
					this.struct2_0[(int)num2].method_1();
				}
			}

			internal uint method_2(uint pos, byte prevByte)
			{
				return ((pos & this.uint_0) << this.int_1) + (uint)(prevByte >> 8 - this.int_1);
			}

			internal byte method_3(Decryptor.Class0 rangeDecoder, uint pos, byte prevByte)
			{
				return this.struct2_0[(int)this.method_2(pos, prevByte)].method_2(rangeDecoder);
			}

			internal byte method_4(Decryptor.Class0 rangeDecoder, uint pos, byte prevByte, byte matchByte)
			{
				return this.struct2_0[(int)this.method_2(pos, prevByte)].method_3(rangeDecoder, matchByte);
			}

			internal Class3()
			{
			}

			internal Decryptor.Class1.Class3.Struct2[] struct2_0;

			internal int int_0;

			internal int int_1;

			internal uint uint_0;

			internal struct Struct2
			{
				internal void method_0()
				{
					this.struct0_0 = new Decryptor.Struct0[768];
				}

				internal void method_1()
				{
					for (int i = 0; i < 768; i++)
					{
						this.struct0_0[i].method_0();
					}
				}

				internal byte method_2(Decryptor.Class0 rangeDecoder)
				{
					uint num = 1U;
					for (;;)
					{
						IL_5C:
						int num2 = -1564410063;
						for (;;)
						{
							int num3 = num2;
							switch ((-(~(-(~(num3 ^ -1974472904) * 1879358361))) - 2600301) % 3)
							{
							case 1:
								num = (num << 1) | this.struct0_0[(int)num].method_1(rangeDecoder);
								num2 = ((num < 256U) ? (-1564410063) : (-319691410));
								continue;
							case 2:
								goto IL_5C;
							}
							goto Block_2;
						}
					}
					Block_2:
					return (byte)num;
				}

				internal byte method_3(Decryptor.Class0 rangeDecoder, byte matchByte)
				{
					uint num = 1U;
					for (;;)
					{
						uint num2 = (uint)((matchByte >> 7) & 1);
						matchByte = (byte)(matchByte << 1);
						uint num3 = this.struct0_0[(int)((1U + num2 << 8) + num)].method_1(rangeDecoder);
						num = (num << 1) | num3;
						if (num2 != num3)
						{
							break;
						}
						if (num >= 256U)
						{
							goto IL_5C;
						}
					}
					while (num < 256U)
					{
						num = (num << 1) | this.struct0_0[(int)num].method_1(rangeDecoder);
					}
					IL_5C:
					return (byte)num;
				}

				internal Decryptor.Struct0[] struct0_0;
			}
		}
	}

	internal class Class4
	{
		internal void method_0(uint windowSize)
		{
			if (this.uint_2 != windowSize)
			{
				this.byte_0 = new byte[windowSize];
			}
			this.uint_2 = windowSize;
			this.uint_0 = 0U;
			this.uint_1 = 0U;
		}

		internal void method_1(Stream stream, bool solid)
		{
			this.method_2();
			this.stream_0 = stream;
			if (!solid)
			{
				this.uint_1 = 0U;
				this.uint_0 = 0U;
			}
		}

		internal void method_2()
		{
			this.method_3();
			this.stream_0 = null;
			Buffer.BlockCopy(new byte[this.byte_0.Length], 0, this.byte_0, 0, this.byte_0.Length);
		}

		internal void method_3()
		{
			uint num = this.uint_0 - this.uint_1;
			if (num == 0U)
			{
				return;
			}
			this.stream_0.Write(this.byte_0, (int)this.uint_1, (int)num);
			if (this.uint_0 >= this.uint_2)
			{
				this.uint_0 = 0U;
			}
			this.uint_1 = this.uint_0;
		}

		internal void method_4(uint distance, uint len)
		{
			uint num = this.uint_0 - distance - 1U;
			if (num >= this.uint_2)
			{
				num += this.uint_2;
			}
			while (len > 0U)
			{
				if (num >= this.uint_2)
				{
					num = 0U;
				}
				byte[] array = this.byte_0;
				uint num2 = this.uint_0;
				this.uint_0 = num2 + 1U;
				array[(int)num2] = this.byte_0[(int)num++];
				if (this.uint_0 >= this.uint_2)
				{
					this.method_3();
				}
				len -= 1U;
			}
		}

		internal void method_5(byte b)
		{
			byte[] array = this.byte_0;
			uint num = this.uint_0;
			this.uint_0 = num + 1U;
			array[(int)num] = b;
			if (this.uint_0 >= this.uint_2)
			{
				this.method_3();
			}
		}

		internal byte method_6(uint distance)
		{
			uint num = this.uint_0 - distance - 1U;
			if (num >= this.uint_2)
			{
				num += this.uint_2;
			}
			return this.byte_0[(int)num];
		}

		internal Class4()
		{
		}

		internal byte[] byte_0;

		internal uint uint_0;

		internal Stream stream_0;

		internal uint uint_1;

		internal uint uint_2;
	}

	internal struct Struct3
	{
		internal void method_0()
		{
			this.uint_0 = 0U;
		}

		internal void method_1()
		{
			if (this.uint_0 < 4U)
			{
				this.uint_0 = 0U;
				return;
			}
			if (this.uint_0 >= 10U)
			{
				this.uint_0 -= 6U;
				return;
			}
			this.uint_0 -= 3U;
		}

		internal void method_2()
		{
			this.uint_0 = ((this.uint_0 < 7U) ? 7U : 10U);
		}

		internal void method_3()
		{
			this.uint_0 = ((this.uint_0 < 7U) ? 8U : 11U);
		}

		internal void method_4()
		{
			this.uint_0 = ((this.uint_0 < 7U) ? 9U : 11U);
		}

		internal bool method_5()
		{
			return this.uint_0 < 7U;
		}

		internal uint uint_0;
	}

	[StructLayout(LayoutKind.Explicit, Size = 2880)]
	internal struct Struct4
	{
	}

	[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 542656)]
	internal struct Struct5
	{
	}
}
