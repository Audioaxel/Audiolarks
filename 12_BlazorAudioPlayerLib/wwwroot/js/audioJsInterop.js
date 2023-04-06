/** 
*  
  *  --- Fade ---
  *  von vol x -> vol y -> in 1/1000 sec
  *  music.fade(x, y, z)
*  
  *  sound.once( 'fade', () => { sound.stop( id ); }, id );
  *  sound.fade( sound.volume(), 0, 1000, id );
  *  
  *    sound1.on('play', function(){
  *      var fadeouttime = 2000;
  *      setTimeout(
  *        function(){
  *          sound1.fade(1, 0, fadeouttime);
  *        },
  *        (sound1.duration() - sound1.seek())*1000 - fadeouttime
  *      );
  *    });
*  
*/

// --- Music ---
var music;
const disposeMusicList = [];

export function playMusic(audioFile)
{
    let fadeIn = false;
    if (music != null) {
        if (music.playing()) {
            stopMusic();
            fadeIn = true;
        }
    }
    music = new Howl({
        src: [audioFile]
    });
    music.play();
    if (fadeIn) {
        music.fade(0, 1, 2000);
    }
}

export function stopMusic()
{
    if (music != null) {
        disposeMusicList.push(music);
        music.once('fade', () => { disposeMusic() });
        music.fade(music.volume(), 0, 2000);
        music = null;
    }
}
function disposeMusic()
{
    disposeMusicList(music[0]).stop();
    disposeMusicList(music[0]).unload();
    disposeMusicList().shift();
}

export function pauseMusic()
{
    if (music != null) {
        if (music.playing()) {
            music.pause()
        }
    }
}



//export function playMusic(audioFile)
//{
//    if (music == null) {
//        music = new Howl({
//            src: [audioFile],
//            //onfade: () => {
//            //    stopId();
//            //}
//        });
//        music.play();
//    } else if (music.playing()) {
//        stopMusic();
//    } else {
//        music.play(audioFile);
//    }
//}

//export function stopMusic() {
//    if (music.playing()) {
//        var id = music.fade(1, 0, 5000);
//        music.on('fade', () => {
//            stopId(id);
//        });
//    }
//}

//function stopId(id) {
//    music.stopMusic(id);
//    console.log('kot');
//}




// --- Sfx ---

var hover;
var click;

export function playHover(audioFile) {
    hover = new Howl({
        src: [audioFile]
    });
    hover.play();
}

export function playClick(audioFile) {
    click = new Howl({
        src: [audioFile]
    });
    click.play();
}

