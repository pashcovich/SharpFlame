using Ninject.Modules;
using SharpFlame.Gui.Actions;
using SharpFlame.Mapping;
using SharpFlame.Mapping.IO;
using SharpFlame.Mapping.IO.FMap;
using SharpFlame.Mapping.IO.LND;
using SharpFlame.Mapping.IO.Wz;
using SharpFlame.Settings;
using SharpFlame.UiOptions;

namespace SharpFlame.Infrastructure
{
    public class NamedBinding
    {
        public const string MapGl = "MapGl";
        public const string TextureGl = "TextureGl";
        public const string FmapLoader = ".fmap";
        public const string WzLoader = ".wz";
        public const string LndLoader = ".lnd";
        public const string GameLoader = ".game";
    }
    public class SharpFlameModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<KeyboardManager>()
                .ToSelf()
                .InSingletonScope();

            this.Bind<SettingsManager>()
                .ToSelf()
                .InSingletonScope();

            this.Bind<Options>()
                .ToSelf()
                .InSingletonScope();
                
            #if DEBUG
            // This is here to keep a reference of it.
            this.Bind<Keylogger>()
                .ToSelf()
                .InSingletonScope();
            #endif



            //GUI
            this.Bind<LoadMapCommand>().ToSelf().InSingletonScope().RegisterOnGlobalEventBroker();

            this.Bind<Gui.Dialogs.Settings>().ToSelf().InTransientScope();

	        this.Bind<ViewInfo>().ToSelf().InSingletonScope().RegisterOnGlobalEventBroker();


            //Mapping.IO
            //this.Bind<SharpFlame.Mapping.IO.FMap.FMapLoader>().ToSelf().InSingletonScope();
            this.Bind<IIOLoader>().To<FMapLoader>().InTransientScope().Named(NamedBinding.FmapLoader);
            this.Bind<SharpFlame.Mapping.IO.FMap.FMapSaver>().ToSelf().InSingletonScope();
            this.Bind<SharpFlame.Mapping.IO.Heightmap.HeightmapSaver>().ToSelf().InSingletonScope();
            //this.Bind<SharpFlame.Mapping.IO.LND.LNDLoader>().ToSelf().InSingletonScope();
            this.Bind<IIOLoader>().To<LNDLoader>().InTransientScope().Named(NamedBinding.LndLoader);
            this.Bind<SharpFlame.Mapping.IO.LND.LNDSaver>().ToSelf().InSingletonScope();
            this.Bind<SharpFlame.Mapping.IO.Minimap.MinimapSaver>().ToSelf().InSingletonScope();
            this.Bind<SharpFlame.Mapping.IO.TTP.TTPLoader>().ToSelf().InSingletonScope();
            this.Bind<SharpFlame.Mapping.IO.TTP.TTPSaver>().ToSelf().InSingletonScope();
            //this.Bind<SharpFlame.Mapping.IO.Wz.WzLoader>().ToSelf().InSingletonScope();
            this.Bind<IIOLoader>().To<WzLoader>().InTransientScope().Named(NamedBinding.WzLoader);
            this.Bind<SharpFlame.Mapping.IO.Wz.WzSaver>().ToSelf().InSingletonScope();

            this.Bind<IIOLoader>().To<GameLoader>().InTransientScope().Named(NamedBinding.GameLoader);
        }
    }
}