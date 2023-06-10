# Oasis

Unity version is 2021.3 LTS (2021.3.15f1 LTS at the time of writing), as the Arcade Simulator project is built on 2021.2.7f1.  

We are using Built-in Render Pipeline, this is due to lightmap baking being impractical for user-created environments (Arcades, Crazy Golf courses, race tracks etc)... all Unity runtime-lightmap baking solutions seemed lacking (on device, remote lightmap baking server etc), and by the time this is a mature product, RTX cards may be relatively standard and affordable, meaning dynamic light/shadows with no baked maps required.

Initial plan for communication between Oasis Unity apps is using named pipes, via a native wrapper (as apparently Unity crashes out trying to do this internally in c#).
