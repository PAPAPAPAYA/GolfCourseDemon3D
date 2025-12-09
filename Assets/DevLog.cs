// 3d golf course demon
// features
        // ball
                // change physic mat to bounce off wall
        // strike ball
                //// strike
                //// only strikable if ball has no speed
                // multi ball situation: click on ball to select
                        //? difficult to select ball
                //// don't accumulate mouse drag duration if mouse isn't moving
        // hole
                //// eat ball
                // get currency
        // caddie
                // spawn ball
                        //// need to come up with a system that dynamically assign and read current ball (maybe need to implement clicking on ball to select and auto select funcs) 
                        //// auto spawn
                        //// start spawn
                        //? timed spawn
                //// object pooling
                //// destroy ball when out of bounds
        // automation 
        // level generation
                // gap between tiles, try CombineMeshesScript
                ////! try to use open as many as possible?
                        //// open can be placed next to any types, but only walled path and open can be placed next to open
                        // might have other problems
                ////! make side info array, tag system, so that open can be open and walled path at the same time
                //// assign hole script
                //// place down start tile
                //// place down hole tile
                //// step logic
                        //// after placing down one tile, step one
                        //// detect which way to go
                // wfc logic
                        //// store side info on each tile
                        //// get side info to determine which tile is fit
                        //// place down tile
                        // probability
                        // it might run into dead end prematurely
                                //! try taking out available tiles if the tiles' possible paths lead to dead ends
                //! dynamically more and less tile makers
                        // deactivate maker if stuck
                        // spawn new makers if split or open
                // ramps & slopes
                // disconnection
                // open spaces
                        // walled left <-> walled right
// support system
        //// camera
                //// basic follow ball func
        //// strike ball ui