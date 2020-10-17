# Introduction
Lib est une solution contenant diveres librairies dont je me sers sur plusieurs de mes programmes sous forme de packages Nuget.
La plupart sont des projets .NetStandard, ils seront détaillés plus bas :)

# Lib.Core
Cette librairie contient essentiellement des classes utilitaires ainsi que des contrats disposant d'implémentations différentes en fonction des plateformes.

# Lib.Core.Mvvm
Cette librairie contient des classes permettant l'utilisation du pattern [MVVM](https://fr.wikipedia.org/wiki/Mod%C3%A8le-vue-vue_mod%C3%A8le) (RelayCommand, ViewModelBase), à voir s'il ne sera pas remplacé plus tard par MvvmLight ou MvvmCross.

# Lib.Core.OnlineServices.OpenWeatherMap
Cette librairie contient des classes permettant l'utilisation de l'API [OpenWeatherMap](https://openweathermap.org/), elle ne couvre évidemment pas toute les ressouces de l'API, uniquement celles qui repondent à mes besoins.

# Lib.Core.OnlineServices.Plex
Cette librairie contient des classes permettant l'utilisation de l'API [Plex](https://www.plex.tv/), elle ne couvre évidemment pas toute les ressouces de l'API, uniquement celles qui repondent à mes besoins.

# Lib.Core.OnlineServices.Rawg
Cette librairie contient des classes permettant l'utilisation de l'API [Rawg](https://rawg.io/), elle ne couvre évidemment pas toute les ressouces de l'API, uniquement celles qui repondent à mes besoins.

# Lib.Core.OnlineServices.Rss
Cette librairie contient des classes permettant l'utilisation des flux RSS [Rawg](https://fr.wikipedia.org/wiki/RSS), uniquement les champs standards sont gérés.

# Lib.Core.OnlineServices.TeamFoundationServer
Cette librairie contient des classes permettant l'utilisation de l'API [Team Foundation Server (2015)](https://fr.wikipedia.org/wiki/Team_Foundation_Server), elle ne couvre évidemment pas toute les ressouces de l'API, uniquement celles qui repondent à mes besoins.

# Lib.Core.OnlineServices.Torrents
Cette librairie contient des classes permettant la récupération de liens Magnet depuis plusieurs sites de [Torrent](https://fr.wikipedia.org/wiki/Torrent), la plupart des sites étant des sites FR.

# Lib.Core.OnlineServices.Trakt
Cette librairie contient des classes permettant l'utilisation de l'API [Trakt](https://trakt.tv/), elle ne couvre évidemment pas toute les ressouces de l'API, uniquement celles qui repondent à mes besoins.

# Lib.Core.OnlineServices.Transmission
Cette librairie contient des classes permettant l'utilisation de l'API RPC [Transmission](https://transmissionbt.com/), elle en focntionne qu'avec un serveur local et ne couvre évidemment pas toute les ressouces de l'API, uniquement celles qui repondent à mes besoins.

# Lib.Core.OnlineServices.Unibet
Cette librairie contient des classes permettant l'utilisation de l'API non publique d'[Unibet](https://www.unibet.fr/), elle ne fonctionne qu'à la condition d'avoir déjà récupéré un cookie depuis le site.

# Lib.Uwp
Cette librairie contient essentiellement des classes utilitaires (converters, helpers) utilisables depuis des apps [UWP](https://docs.microsoft.com/fr-fr/windows/uwp/)

# Lib.Uwp.Mvvm
Cette librairie contient des classes permettant l'utilisation du pattern [MVVM](https://fr.wikipedia.org/wiki/Mod%C3%A8le-vue-vue_mod%C3%A8le) depuis une app [UWP](https://docs.microsoft.com/fr-fr/windows/uwp/).
