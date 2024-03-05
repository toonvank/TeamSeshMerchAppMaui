; ModuleID = 'marshal_methods.x86.ll'
source_filename = "marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [161 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [322 x i32] [
	i32 15721112, ; 0: System.Runtime.Intrinsics.dll => 0xefe298 => 138
	i32 33939330, ; 1: Microsoft.Threading.Tasks => 0x205df82 => 44
	i32 38948123, ; 2: ar\Microsoft.Maui.Controls.resources.dll => 0x2524d1b => 0
	i32 39109920, ; 3: Newtonsoft.Json.dll => 0x254c520 => 61
	i32 42244203, ; 4: he\Microsoft.Maui.Controls.resources.dll => 0x284986b => 9
	i32 42639949, ; 5: System.Threading.Thread => 0x28aa24d => 148
	i32 67008169, ; 6: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 33
	i32 72070932, ; 7: Microsoft.Maui.Graphics.dll => 0x44bb714 => 58
	i32 83839681, ; 8: ms\Microsoft.Maui.Controls.resources.dll => 0x4ff4ac1 => 17
	i32 117431740, ; 9: System.Runtime.InteropServices => 0x6ffddbc => 137
	i32 136584136, ; 10: zh-Hans\Microsoft.Maui.Controls.resources.dll => 0x8241bc8 => 32
	i32 140062828, ; 11: sk\Microsoft.Maui.Controls.resources.dll => 0x859306c => 25
	i32 165246403, ; 12: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 69
	i32 182336117, ; 13: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 87
	i32 185010651, ; 14: System.Net.Http.Primitives => 0xb0709db => 60
	i32 205061960, ; 15: System.ComponentModel => 0xc38ff48 => 104
	i32 209399409, ; 16: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 67
	i32 220171995, ; 17: System.Diagnostics.Debug => 0xd1f8edb => 108
	i32 230752869, ; 18: Microsoft.CSharp.dll => 0xdc10265 => 95
	i32 246610117, ; 19: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 131
	i32 317674968, ; 20: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 30
	i32 318968648, ; 21: Xamarin.AndroidX.Activity.dll => 0x13031348 => 64
	i32 321963286, ; 22: fr\Microsoft.Maui.Controls.resources.dll => 0x1330c516 => 8
	i32 342366114, ; 23: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 76
	i32 379916513, ; 24: System.Threading.Thread.dll => 0x16a510e1 => 148
	i32 385762202, ; 25: System.Memory.dll => 0x16fe439a => 119
	i32 395744057, ; 26: _Microsoft.Android.Resource.Designer => 0x17969339 => 34
	i32 409257351, ; 27: tr\Microsoft.Maui.Controls.resources.dll => 0x1864c587 => 28
	i32 442565967, ; 28: System.Collections => 0x1a61054f => 100
	i32 450948140, ; 29: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 75
	i32 456227837, ; 30: System.Web.HttpUtility.dll => 0x1b317bfd => 150
	i32 459347974, ; 31: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 141
	i32 465846621, ; 32: mscorlib => 0x1bc4415d => 155
	i32 469710990, ; 33: System.dll => 0x1bff388e => 154
	i32 489220957, ; 34: es\Microsoft.Maui.Controls.resources.dll => 0x1d28eb5d => 6
	i32 498788369, ; 35: System.ObjectModel => 0x1dbae811 => 126
	i32 513247710, ; 36: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 52
	i32 538707440, ; 37: th\Microsoft.Maui.Controls.resources.dll => 0x201c05f0 => 27
	i32 539058512, ; 38: Microsoft.Extensions.Logging => 0x20216150 => 49
	i32 540030774, ; 39: System.IO.FileSystem.dll => 0x20303736 => 116
	i32 545304856, ; 40: System.Runtime.Extensions => 0x2080b118 => 136
	i32 597488923, ; 41: CommunityToolkit.Maui => 0x239cf51b => 36
	i32 627609679, ; 42: Xamarin.AndroidX.CustomView => 0x2568904f => 73
	i32 627931235, ; 43: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 19
	i32 643868501, ; 44: System.Net => 0x2660a755 => 124
	i32 672442732, ; 45: System.Collections.Concurrent => 0x2814a96c => 96
	i32 690569205, ; 46: System.Xml.Linq.dll => 0x29293ff5 => 151
	i32 759454413, ; 47: System.Net.Requests => 0x2d445acd => 123
	i32 775507847, ; 48: System.IO.Compression => 0x2e394f87 => 115
	i32 777317022, ; 49: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 25
	i32 789151979, ; 50: Microsoft.Extensions.Options => 0x2f0980eb => 51
	i32 804715423, ; 51: System.Data.Common => 0x2ff6fb9f => 107
	i32 823281589, ; 52: System.Private.Uri.dll => 0x311247b5 => 127
	i32 830298997, ; 53: System.IO.Compression.Brotli => 0x317d5b75 => 114
	i32 869139383, ; 54: hi\Microsoft.Maui.Controls.resources.dll => 0x33ce03b7 => 10
	i32 880668424, ; 55: ru\Microsoft.Maui.Controls.resources.dll => 0x347def08 => 24
	i32 898440345, ; 56: CsvHelper => 0x358d1c99 => 39
	i32 904024072, ; 57: System.ComponentModel.Primitives.dll => 0x35e25008 => 102
	i32 918734561, ; 58: pt-BR\Microsoft.Maui.Controls.resources.dll => 0x36c2c6e1 => 21
	i32 955402788, ; 59: Newtonsoft.Json => 0x38f24a24 => 61
	i32 961460050, ; 60: it\Microsoft.Maui.Controls.resources.dll => 0x394eb752 => 14
	i32 967690846, ; 61: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 76
	i32 975874589, ; 62: System.Xml.XDocument => 0x3a2aaa1d => 153
	i32 990727110, ; 63: ro\Microsoft.Maui.Controls.resources.dll => 0x3b0d4bc6 => 23
	i32 992768348, ; 64: System.Collections.dll => 0x3b2c715c => 100
	i32 994442037, ; 65: System.IO.FileSystem => 0x3b45fb35 => 116
	i32 1012816738, ; 66: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 86
	i32 1019214401, ; 67: System.Drawing => 0x3cbffa41 => 112
	i32 1028951442, ; 68: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 48
	i32 1035644815, ; 69: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 65
	i32 1036536393, ; 70: System.Drawing.Primitives.dll => 0x3dc84a49 => 111
	i32 1043950537, ; 71: de\Microsoft.Maui.Controls.resources.dll => 0x3e396bc9 => 4
	i32 1044663988, ; 72: System.Linq.Expressions.dll => 0x3e444eb4 => 117
	i32 1052210849, ; 73: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 78
	i32 1082857460, ; 74: System.ComponentModel.TypeConverter => 0x408b17f4 => 103
	i32 1084122840, ; 75: Xamarin.Kotlin.StdLib => 0x409e66d8 => 91
	i32 1098259244, ; 76: System => 0x41761b2c => 154
	i32 1108272742, ; 77: sv\Microsoft.Maui.Controls.resources.dll => 0x420ee666 => 26
	i32 1113301301, ; 78: BonesMerch2024 => 0x425ba135 => 94
	i32 1117529484, ; 79: pl\Microsoft.Maui.Controls.resources.dll => 0x429c258c => 20
	i32 1118262833, ; 80: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 16
	i32 1168523401, ; 81: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 22
	i32 1178241025, ; 82: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 83
	i32 1214827643, ; 83: CommunityToolkit.Mvvm => 0x4868cc7b => 38
	i32 1245772053, ; 84: FireSharp.dll => 0x4a40f915 => 41
	i32 1260983243, ; 85: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 2
	i32 1293217323, ; 86: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 74
	i32 1308624726, ; 87: hr\Microsoft.Maui.Controls.resources.dll => 0x4e000756 => 11
	i32 1324164729, ; 88: System.Linq => 0x4eed2679 => 118
	i32 1336711579, ; 89: zh-HK\Microsoft.Maui.Controls.resources.dll => 0x4fac999b => 31
	i32 1373134921, ; 90: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 32
	i32 1376561836, ; 91: Plugin.DownloadManager.Abstractions => 0x520caaac => 62
	i32 1376866003, ; 92: Xamarin.AndroidX.SavedState => 0x52114ed3 => 86
	i32 1379779777, ; 93: System.Resources.ResourceManager => 0x523dc4c1 => 135
	i32 1406073936, ; 94: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 70
	i32 1408764838, ; 95: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 140
	i32 1430672901, ; 96: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 0
	i32 1457743152, ; 97: System.Runtime.Extensions.dll => 0x56e36530 => 136
	i32 1461004990, ; 98: es\Microsoft.Maui.Controls.resources => 0x57152abe => 6
	i32 1461234159, ; 99: System.Collections.Immutable.dll => 0x5718a9ef => 97
	i32 1462112819, ; 100: System.IO.Compression.dll => 0x57261233 => 115
	i32 1469204771, ; 101: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 66
	i32 1470490898, ; 102: Microsoft.Extensions.Primitives => 0x57a5e912 => 52
	i32 1479771757, ; 103: System.Collections.Immutable => 0x5833866d => 97
	i32 1480492111, ; 104: System.IO.Compression.Brotli.dll => 0x583e844f => 114
	i32 1519561301, ; 105: BonesMerch2024.dll => 0x5a92aa55 => 94
	i32 1526286932, ; 106: vi\Microsoft.Maui.Controls.resources.dll => 0x5af94a54 => 30
	i32 1543031311, ; 107: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 146
	i32 1550322496, ; 108: System.Reflection.Extensions.dll => 0x5c680b40 => 132
	i32 1622152042, ; 109: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 80
	i32 1622358360, ; 110: System.Dynamic.Runtime => 0x60b33958 => 113
	i32 1624863272, ; 111: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 89
	i32 1634654947, ; 112: CommunityToolkit.Maui.Core.dll => 0x616edae3 => 37
	i32 1636350590, ; 113: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 72
	i32 1639515021, ; 114: System.Net.Http.dll => 0x61b9038d => 120
	i32 1639986890, ; 115: System.Text.RegularExpressions => 0x61c036ca => 146
	i32 1641389582, ; 116: System.ComponentModel.EventBasedAsync.dll => 0x61d59e0e => 101
	i32 1657153582, ; 117: System.Runtime => 0x62c6282e => 142
	i32 1658251792, ; 118: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 90
	i32 1677501392, ; 119: System.Net.Primitives.dll => 0x63fca3d0 => 122
	i32 1679769178, ; 120: System.Security.Cryptography => 0x641f3e5a => 143
	i32 1701541528, ; 121: System.Diagnostics.Debug.dll => 0x656b7698 => 108
	i32 1703690872, ; 122: Microsoft.Threading.Tasks.Extensions.dll => 0x658c4278 => 43
	i32 1726116996, ; 123: System.Reflection.dll => 0x66e27484 => 134
	i32 1729485958, ; 124: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 68
	i32 1743415430, ; 125: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 1
	i32 1763938596, ; 126: System.Diagnostics.TraceSource.dll => 0x69239124 => 110
	i32 1765942094, ; 127: System.Reflection.Extensions => 0x6942234e => 132
	i32 1766324549, ; 128: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 87
	i32 1770582343, ; 129: Microsoft.Extensions.Logging.dll => 0x6988f147 => 49
	i32 1776026572, ; 130: System.Core.dll => 0x69dc03cc => 106
	i32 1780572499, ; 131: Mono.Android.Runtime.dll => 0x6a216153 => 159
	i32 1782862114, ; 132: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 17
	i32 1788241197, ; 133: Xamarin.AndroidX.Fragment => 0x6a96652d => 75
	i32 1793755602, ; 134: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 9
	i32 1808609942, ; 135: Xamarin.AndroidX.Loader => 0x6bcd3296 => 80
	i32 1813058853, ; 136: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 91
	i32 1813201214, ; 137: Xamarin.Google.Android.Material => 0x6c13413e => 90
	i32 1818569960, ; 138: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 84
	i32 1824175904, ; 139: System.Text.Encoding.Extensions => 0x6cbab720 => 144
	i32 1824722060, ; 140: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 140
	i32 1828688058, ; 141: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 50
	i32 1853025655, ; 142: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 26
	i32 1858542181, ; 143: System.Linq.Expressions => 0x6ec71a65 => 117
	i32 1870277092, ; 144: System.Reflection.Primitives => 0x6f7a29e4 => 133
	i32 1875935024, ; 145: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 8
	i32 1893218855, ; 146: cs\Microsoft.Maui.Controls.resources.dll => 0x70d83a27 => 2
	i32 1900610850, ; 147: System.Resources.ResourceManager.dll => 0x71490522 => 135
	i32 1910275211, ; 148: System.Collections.NonGeneric.dll => 0x71dc7c8b => 98
	i32 1939592360, ; 149: System.Private.Xml.Linq => 0x739bd4a8 => 128
	i32 1953182387, ; 150: id\Microsoft.Maui.Controls.resources.dll => 0x746b32b3 => 13
	i32 1968388702, ; 151: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 45
	i32 2003115576, ; 152: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 5
	i32 2004783961, ; 153: FireSharp => 0x777e9359 => 41
	i32 2019465201, ; 154: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 78
	i32 2045470958, ; 155: System.Private.Xml => 0x79eb68ee => 129
	i32 2054170072, ; 156: CodeHollow.FeedReader => 0x7a7025d8 => 35
	i32 2055257422, ; 157: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 77
	i32 2066184531, ; 158: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 4
	i32 2070888862, ; 159: System.Diagnostics.TraceSource => 0x7b6f419e => 110
	i32 2079903147, ; 160: System.Runtime.dll => 0x7bf8cdab => 142
	i32 2090596640, ; 161: System.Numerics.Vectors => 0x7c9bf920 => 125
	i32 2094816946, ; 162: Plugin.DownloadManager.Abstractions.dll => 0x7cdc5eb2 => 62
	i32 2101843933, ; 163: IF.Lastfm.Core => 0x7d4797dd => 42
	i32 2127167465, ; 164: System.Console => 0x7ec9ffe9 => 105
	i32 2142473426, ; 165: System.Collections.Specialized => 0x7fb38cd2 => 99
	i32 2159891885, ; 166: Microsoft.Maui => 0x80bd55ad => 56
	i32 2169148018, ; 167: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 12
	i32 2181898931, ; 168: Microsoft.Extensions.Options.dll => 0x820d22b3 => 51
	i32 2192057212, ; 169: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 50
	i32 2193016926, ; 170: System.ObjectModel.dll => 0x82b6c85e => 126
	i32 2201107256, ; 171: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 92
	i32 2201231467, ; 172: System.Net.Http => 0x8334206b => 120
	i32 2207618523, ; 173: it\Microsoft.Maui.Controls.resources => 0x839595db => 14
	i32 2216717168, ; 174: Firebase.Auth.dll => 0x84206b70 => 40
	i32 2266799131, ; 175: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 46
	i32 2279755925, ; 176: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 85
	i32 2298471582, ; 177: System.Net.Mail => 0x88ffe49e => 121
	i32 2303942373, ; 178: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 18
	i32 2305521784, ; 179: System.Private.CoreLib.dll => 0x896b7878 => 157
	i32 2346898248, ; 180: IF.Lastfm.Core.dll => 0x8be2d348 => 42
	i32 2353062107, ; 181: System.Net.Primitives => 0x8c40e0db => 122
	i32 2366048013, ; 182: hu\Microsoft.Maui.Controls.resources.dll => 0x8d07070d => 12
	i32 2368005991, ; 183: System.Xml.ReaderWriter.dll => 0x8d24e767 => 152
	i32 2371007202, ; 184: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 45
	i32 2395872292, ; 185: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 13
	i32 2401565422, ; 186: System.Web.HttpUtility => 0x8f24faee => 150
	i32 2427813419, ; 187: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 10
	i32 2435356389, ; 188: System.Console.dll => 0x912896e5 => 105
	i32 2454642406, ; 189: System.Text.Encoding.dll => 0x924edee6 => 145
	i32 2471841756, ; 190: netstandard.dll => 0x93554fdc => 156
	i32 2475788418, ; 191: Java.Interop.dll => 0x93918882 => 158
	i32 2480646305, ; 192: Microsoft.Maui.Controls => 0x93dba8a1 => 54
	i32 2483903535, ; 193: System.ComponentModel.EventBasedAsync => 0x940d5c2f => 101
	i32 2503351294, ; 194: ko\Microsoft.Maui.Controls.resources.dll => 0x95361bfe => 16
	i32 2538310050, ; 195: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 131
	i32 2550873716, ; 196: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 11
	i32 2562349572, ; 197: Microsoft.CSharp => 0x98ba5a04 => 95
	i32 2576534780, ; 198: ja\Microsoft.Maui.Controls.resources.dll => 0x9992ccfc => 15
	i32 2585220780, ; 199: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 144
	i32 2593496499, ; 200: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 20
	i32 2597161585, ; 201: Plugin.DownloadManager => 0x9acd8a71 => 63
	i32 2605712449, ; 202: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 92
	i32 2611359322, ; 203: ZstdSharp.dll => 0x9ba62e5a => 93
	i32 2617129537, ; 204: System.Private.Xml.dll => 0x9bfe3a41 => 129
	i32 2620871830, ; 205: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 72
	i32 2626831493, ; 206: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 15
	i32 2629600743, ; 207: System.Net.Http.Extensions.dll => 0x9cbc85e7 => 59
	i32 2664396074, ; 208: System.Xml.XDocument.dll => 0x9ecf752a => 153
	i32 2665622720, ; 209: System.Drawing.Primitives => 0x9ee22cc0 => 111
	i32 2676780864, ; 210: System.Data.Common.dll => 0x9f8c6f40 => 107
	i32 2715334215, ; 211: System.Threading.Tasks.dll => 0xa1d8b647 => 147
	i32 2724373263, ; 212: System.Runtime.Numerics.dll => 0xa262a30f => 139
	i32 2732626843, ; 213: Xamarin.AndroidX.Activity => 0xa2e0939b => 64
	i32 2737747696, ; 214: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 66
	i32 2740698338, ; 215: ca\Microsoft.Maui.Controls.resources.dll => 0xa35bbce2 => 1
	i32 2752995522, ; 216: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 21
	i32 2758225723, ; 217: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 55
	i32 2764765095, ; 218: Microsoft.Maui.dll => 0xa4caf7a7 => 56
	i32 2778768386, ; 219: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 88
	i32 2785988530, ; 220: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 27
	i32 2801831435, ; 221: Microsoft.Maui.Graphics => 0xa7008e0b => 58
	i32 2810250172, ; 222: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 70
	i32 2853208004, ; 223: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 88
	i32 2861189240, ; 224: Microsoft.Maui.Essentials => 0xaa8a4878 => 57
	i32 2868488919, ; 225: CommunityToolkit.Maui.Core => 0xaaf9aad7 => 37
	i32 2887636118, ; 226: System.Net.dll => 0xac1dd496 => 124
	i32 2900621748, ; 227: System.Dynamic.Runtime.dll => 0xace3f9b4 => 113
	i32 2901442782, ; 228: System.Reflection => 0xacf080de => 134
	i32 2905242038, ; 229: mscorlib.dll => 0xad2a79b6 => 155
	i32 2909740682, ; 230: System.Private.CoreLib => 0xad6f1e8a => 157
	i32 2916838712, ; 231: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 89
	i32 2919462931, ; 232: System.Numerics.Vectors.dll => 0xae037813 => 125
	i32 2959614098, ; 233: System.ComponentModel.dll => 0xb0682092 => 104
	i32 2978675010, ; 234: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 74
	i32 3038032645, ; 235: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 34
	i32 3053864966, ; 236: fi\Microsoft.Maui.Controls.resources.dll => 0xb6064806 => 7
	i32 3057625584, ; 237: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 81
	i32 3059408633, ; 238: Mono.Android.Runtime => 0xb65adef9 => 159
	i32 3059793426, ; 239: System.ComponentModel.Primitives => 0xb660be12 => 102
	i32 3075834255, ; 240: System.Threading.Tasks => 0xb755818f => 147
	i32 3089219899, ; 241: ZstdSharp => 0xb821c13b => 93
	i32 3159123045, ; 242: System.Reflection.Primitives.dll => 0xbc4c6465 => 133
	i32 3178803400, ; 243: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 82
	i32 3202900353, ; 244: Microsoft.Threading.Tasks.Extensions => 0xbee86181 => 43
	i32 3220365878, ; 245: System.Threading => 0xbff2e236 => 149
	i32 3258312781, ; 246: Xamarin.AndroidX.CardView => 0xc235e84d => 68
	i32 3299363146, ; 247: System.Text.Encoding => 0xc4a8494a => 145
	i32 3305363605, ; 248: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 7
	i32 3316684772, ; 249: System.Net.Requests.dll => 0xc5b097e4 => 123
	i32 3317135071, ; 250: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 73
	i32 3346324047, ; 251: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 83
	i32 3357674450, ; 252: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 24
	i32 3362522851, ; 253: Xamarin.AndroidX.Core => 0xc86c06e3 => 71
	i32 3366347497, ; 254: Java.Interop => 0xc8a662e9 => 158
	i32 3374999561, ; 255: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 85
	i32 3381016424, ; 256: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 3
	i32 3428513518, ; 257: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 47
	i32 3430777524, ; 258: netstandard => 0xcc7d82b4 => 156
	i32 3452344032, ; 259: Microsoft.Maui.Controls.Compatibility.dll => 0xcdc696e0 => 53
	i32 3458724246, ; 260: pt\Microsoft.Maui.Controls.resources.dll => 0xce27f196 => 22
	i32 3471940407, ; 261: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 103
	i32 3476120550, ; 262: Mono.Android => 0xcf3163e6 => 160
	i32 3484440000, ; 263: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 23
	i32 3509114376, ; 264: System.Xml.Linq => 0xd128d608 => 151
	i32 3522916314, ; 265: System.Net.Http.Extensions => 0xd1fb6fda => 59
	i32 3528233092, ; 266: Plugin.DownloadManager.dll => 0xd24c9084 => 63
	i32 3580758918, ; 267: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 31
	i32 3592228221, ; 268: zh-Hant\Microsoft.Maui.Controls.resources.dll => 0xd61d0d7d => 33
	i32 3608519521, ; 269: System.Linq.dll => 0xd715a361 => 118
	i32 3641597786, ; 270: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 77
	i32 3643446276, ; 271: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 28
	i32 3643854240, ; 272: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 82
	i32 3657292374, ; 273: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 46
	i32 3672681054, ; 274: Mono.Android.dll => 0xdae8aa5e => 160
	i32 3682565725, ; 275: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 67
	i32 3716563718, ; 276: System.Runtime.Intrinsics => 0xdd864306 => 138
	i32 3724971120, ; 277: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 81
	i32 3748608112, ; 278: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 109
	i32 3751619990, ; 279: da\Microsoft.Maui.Controls.resources.dll => 0xdf9d2d96 => 3
	i32 3786282454, ; 280: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 69
	i32 3792276235, ; 281: System.Collections.NonGeneric => 0xe2098b0b => 98
	i32 3798658073, ; 282: System.Net.Http.Primitives.dll => 0xe26aec19 => 60
	i32 3800979733, ; 283: Microsoft.Maui.Controls.Compatibility => 0xe28e5915 => 53
	i32 3802395368, ; 284: System.Collections.Specialized.dll => 0xe2a3f2e8 => 99
	i32 3817368567, ; 285: CommunityToolkit.Maui.dll => 0xe3886bf7 => 36
	i32 3818918118, ; 286: CsvHelper.dll => 0xe3a010e6 => 39
	i32 3823082795, ; 287: System.Security.Cryptography.dll => 0xe3df9d2b => 143
	i32 3841636137, ; 288: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 48
	i32 3844307129, ; 289: System.Net.Mail.dll => 0xe52378b9 => 121
	i32 3849253459, ; 290: System.Runtime.InteropServices.dll => 0xe56ef253 => 137
	i32 3896106733, ; 291: System.Collections.Concurrent.dll => 0xe839deed => 96
	i32 3896760992, ; 292: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 71
	i32 3920221145, ; 293: nl\Microsoft.Maui.Controls.resources.dll => 0xe9a9d3d9 => 19
	i32 3928044579, ; 294: System.Xml.ReaderWriter => 0xea213423 => 152
	i32 3931092270, ; 295: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 84
	i32 3955647286, ; 296: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 65
	i32 4024013275, ; 297: Firebase.Auth => 0xefd991db => 40
	i32 4025784931, ; 298: System.Memory => 0xeff49a63 => 119
	i32 4046471985, ; 299: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 55
	i32 4054681211, ; 300: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 130
	i32 4068434129, ; 301: System.Private.Xml.Linq.dll => 0xf27f60d1 => 128
	i32 4073602200, ; 302: System.Threading.dll => 0xf2ce3c98 => 149
	i32 4091086043, ; 303: el\Microsoft.Maui.Controls.resources.dll => 0xf3d904db => 5
	i32 4094352644, ; 304: Microsoft.Maui.Essentials.dll => 0xf40add04 => 57
	i32 4099507663, ; 305: System.Drawing.dll => 0xf45985cf => 112
	i32 4100113165, ; 306: System.Private.Uri => 0xf462c30d => 127
	i32 4103439459, ; 307: uk\Microsoft.Maui.Controls.resources.dll => 0xf4958463 => 29
	i32 4126470640, ; 308: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 47
	i32 4136602218, ; 309: Microsoft.Threading.Tasks.dll => 0xf68f8a6a => 44
	i32 4147896353, ; 310: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 130
	i32 4150914736, ; 311: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 29
	i32 4151237749, ; 312: System.Core => 0xf76edc75 => 106
	i32 4181436372, ; 313: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 141
	i32 4182413190, ; 314: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 79
	i32 4213026141, ; 315: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 109
	i32 4234390579, ; 316: CodeHollow.FeedReader.dll => 0xfc63ac33 => 35
	i32 4249188766, ; 317: nb\Microsoft.Maui.Controls.resources.dll => 0xfd45799e => 18
	i32 4271975918, ; 318: Microsoft.Maui.Controls.dll => 0xfea12dee => 54
	i32 4274623895, ; 319: CommunityToolkit.Mvvm.dll => 0xfec99597 => 38
	i32 4274976490, ; 320: System.Runtime.Numerics => 0xfecef6ea => 139
	i32 4292120959 ; 321: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 79
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [322 x i32] [
	i32 138, ; 0
	i32 44, ; 1
	i32 0, ; 2
	i32 61, ; 3
	i32 9, ; 4
	i32 148, ; 5
	i32 33, ; 6
	i32 58, ; 7
	i32 17, ; 8
	i32 137, ; 9
	i32 32, ; 10
	i32 25, ; 11
	i32 69, ; 12
	i32 87, ; 13
	i32 60, ; 14
	i32 104, ; 15
	i32 67, ; 16
	i32 108, ; 17
	i32 95, ; 18
	i32 131, ; 19
	i32 30, ; 20
	i32 64, ; 21
	i32 8, ; 22
	i32 76, ; 23
	i32 148, ; 24
	i32 119, ; 25
	i32 34, ; 26
	i32 28, ; 27
	i32 100, ; 28
	i32 75, ; 29
	i32 150, ; 30
	i32 141, ; 31
	i32 155, ; 32
	i32 154, ; 33
	i32 6, ; 34
	i32 126, ; 35
	i32 52, ; 36
	i32 27, ; 37
	i32 49, ; 38
	i32 116, ; 39
	i32 136, ; 40
	i32 36, ; 41
	i32 73, ; 42
	i32 19, ; 43
	i32 124, ; 44
	i32 96, ; 45
	i32 151, ; 46
	i32 123, ; 47
	i32 115, ; 48
	i32 25, ; 49
	i32 51, ; 50
	i32 107, ; 51
	i32 127, ; 52
	i32 114, ; 53
	i32 10, ; 54
	i32 24, ; 55
	i32 39, ; 56
	i32 102, ; 57
	i32 21, ; 58
	i32 61, ; 59
	i32 14, ; 60
	i32 76, ; 61
	i32 153, ; 62
	i32 23, ; 63
	i32 100, ; 64
	i32 116, ; 65
	i32 86, ; 66
	i32 112, ; 67
	i32 48, ; 68
	i32 65, ; 69
	i32 111, ; 70
	i32 4, ; 71
	i32 117, ; 72
	i32 78, ; 73
	i32 103, ; 74
	i32 91, ; 75
	i32 154, ; 76
	i32 26, ; 77
	i32 94, ; 78
	i32 20, ; 79
	i32 16, ; 80
	i32 22, ; 81
	i32 83, ; 82
	i32 38, ; 83
	i32 41, ; 84
	i32 2, ; 85
	i32 74, ; 86
	i32 11, ; 87
	i32 118, ; 88
	i32 31, ; 89
	i32 32, ; 90
	i32 62, ; 91
	i32 86, ; 92
	i32 135, ; 93
	i32 70, ; 94
	i32 140, ; 95
	i32 0, ; 96
	i32 136, ; 97
	i32 6, ; 98
	i32 97, ; 99
	i32 115, ; 100
	i32 66, ; 101
	i32 52, ; 102
	i32 97, ; 103
	i32 114, ; 104
	i32 94, ; 105
	i32 30, ; 106
	i32 146, ; 107
	i32 132, ; 108
	i32 80, ; 109
	i32 113, ; 110
	i32 89, ; 111
	i32 37, ; 112
	i32 72, ; 113
	i32 120, ; 114
	i32 146, ; 115
	i32 101, ; 116
	i32 142, ; 117
	i32 90, ; 118
	i32 122, ; 119
	i32 143, ; 120
	i32 108, ; 121
	i32 43, ; 122
	i32 134, ; 123
	i32 68, ; 124
	i32 1, ; 125
	i32 110, ; 126
	i32 132, ; 127
	i32 87, ; 128
	i32 49, ; 129
	i32 106, ; 130
	i32 159, ; 131
	i32 17, ; 132
	i32 75, ; 133
	i32 9, ; 134
	i32 80, ; 135
	i32 91, ; 136
	i32 90, ; 137
	i32 84, ; 138
	i32 144, ; 139
	i32 140, ; 140
	i32 50, ; 141
	i32 26, ; 142
	i32 117, ; 143
	i32 133, ; 144
	i32 8, ; 145
	i32 2, ; 146
	i32 135, ; 147
	i32 98, ; 148
	i32 128, ; 149
	i32 13, ; 150
	i32 45, ; 151
	i32 5, ; 152
	i32 41, ; 153
	i32 78, ; 154
	i32 129, ; 155
	i32 35, ; 156
	i32 77, ; 157
	i32 4, ; 158
	i32 110, ; 159
	i32 142, ; 160
	i32 125, ; 161
	i32 62, ; 162
	i32 42, ; 163
	i32 105, ; 164
	i32 99, ; 165
	i32 56, ; 166
	i32 12, ; 167
	i32 51, ; 168
	i32 50, ; 169
	i32 126, ; 170
	i32 92, ; 171
	i32 120, ; 172
	i32 14, ; 173
	i32 40, ; 174
	i32 46, ; 175
	i32 85, ; 176
	i32 121, ; 177
	i32 18, ; 178
	i32 157, ; 179
	i32 42, ; 180
	i32 122, ; 181
	i32 12, ; 182
	i32 152, ; 183
	i32 45, ; 184
	i32 13, ; 185
	i32 150, ; 186
	i32 10, ; 187
	i32 105, ; 188
	i32 145, ; 189
	i32 156, ; 190
	i32 158, ; 191
	i32 54, ; 192
	i32 101, ; 193
	i32 16, ; 194
	i32 131, ; 195
	i32 11, ; 196
	i32 95, ; 197
	i32 15, ; 198
	i32 144, ; 199
	i32 20, ; 200
	i32 63, ; 201
	i32 92, ; 202
	i32 93, ; 203
	i32 129, ; 204
	i32 72, ; 205
	i32 15, ; 206
	i32 59, ; 207
	i32 153, ; 208
	i32 111, ; 209
	i32 107, ; 210
	i32 147, ; 211
	i32 139, ; 212
	i32 64, ; 213
	i32 66, ; 214
	i32 1, ; 215
	i32 21, ; 216
	i32 55, ; 217
	i32 56, ; 218
	i32 88, ; 219
	i32 27, ; 220
	i32 58, ; 221
	i32 70, ; 222
	i32 88, ; 223
	i32 57, ; 224
	i32 37, ; 225
	i32 124, ; 226
	i32 113, ; 227
	i32 134, ; 228
	i32 155, ; 229
	i32 157, ; 230
	i32 89, ; 231
	i32 125, ; 232
	i32 104, ; 233
	i32 74, ; 234
	i32 34, ; 235
	i32 7, ; 236
	i32 81, ; 237
	i32 159, ; 238
	i32 102, ; 239
	i32 147, ; 240
	i32 93, ; 241
	i32 133, ; 242
	i32 82, ; 243
	i32 43, ; 244
	i32 149, ; 245
	i32 68, ; 246
	i32 145, ; 247
	i32 7, ; 248
	i32 123, ; 249
	i32 73, ; 250
	i32 83, ; 251
	i32 24, ; 252
	i32 71, ; 253
	i32 158, ; 254
	i32 85, ; 255
	i32 3, ; 256
	i32 47, ; 257
	i32 156, ; 258
	i32 53, ; 259
	i32 22, ; 260
	i32 103, ; 261
	i32 160, ; 262
	i32 23, ; 263
	i32 151, ; 264
	i32 59, ; 265
	i32 63, ; 266
	i32 31, ; 267
	i32 33, ; 268
	i32 118, ; 269
	i32 77, ; 270
	i32 28, ; 271
	i32 82, ; 272
	i32 46, ; 273
	i32 160, ; 274
	i32 67, ; 275
	i32 138, ; 276
	i32 81, ; 277
	i32 109, ; 278
	i32 3, ; 279
	i32 69, ; 280
	i32 98, ; 281
	i32 60, ; 282
	i32 53, ; 283
	i32 99, ; 284
	i32 36, ; 285
	i32 39, ; 286
	i32 143, ; 287
	i32 48, ; 288
	i32 121, ; 289
	i32 137, ; 290
	i32 96, ; 291
	i32 71, ; 292
	i32 19, ; 293
	i32 152, ; 294
	i32 84, ; 295
	i32 65, ; 296
	i32 40, ; 297
	i32 119, ; 298
	i32 55, ; 299
	i32 130, ; 300
	i32 128, ; 301
	i32 149, ; 302
	i32 5, ; 303
	i32 57, ; 304
	i32 112, ; 305
	i32 127, ; 306
	i32 29, ; 307
	i32 47, ; 308
	i32 44, ; 309
	i32 130, ; 310
	i32 29, ; 311
	i32 106, ; 312
	i32 141, ; 313
	i32 79, ; 314
	i32 109, ; 315
	i32 35, ; 316
	i32 18, ; 317
	i32 54, ; 318
	i32 38, ; 319
	i32 139, ; 320
	i32 79 ; 321
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.1xx @ af27162bee43b7fecdca59b4f67aa8c175cbc875"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"NumRegisterParameters", i32 0}
