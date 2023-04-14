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
        src: [audioFile],
        format: ['mp3'],
        html5: true,
        autoplay: false,
        volume: 1,
        buffer: true,
        onplay: function() {
            audioVisualizer();
        }
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
    disposeMusicList[0].stop();
    disposeMusicList[0].unload();
    disposeMusicList.shift();
}


export function pauseMusic()
{
    if (music != null) {
        if (music.playing()) {
            music.once('fade', () => { music.pause(); });
            
            music.fade(music.volume(), 0, 2000);
        }
    }
}

export function resumeMusic() {
    if (music != null) {
        if (!music.playing()) {
            music.play();
            music.fade(0, 1, 2000);
        }
    }
}

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

// ____________________________________________________________
// === Audio VIsualizer =========================================

const container = document.getElementById('container');
const canvas = document.getElementById('canvas1');

canvas.width = window.innerWidth;
canvas.height = window.innerHeight;
const ctx = canvas.getContext('2d');
let audioSource;
let analyser;

const audioContext = new (window.AudioContext || window.webkitAudioContext)();

function audioVisualizer()
{
    const sourceNode = audioContext.createMediaStreamSource(music._sounds[0]._node.captureStream());
    const analyser = audioContext.createAnalyser();
    sourceNode.connect(analyser);
    analyser.connect(audioContext.destination);

    analyser.fftSize = 2048; // amount /2 = number of bars
    const bufferLength = analyser.frequencyBinCount;
    const dataArray = new Uint8Array(bufferLength);

    const barWidth = canvas.width/2/bufferLength;
    let barHeight;
    let x;

    function animate() {
        x = 0;
        ctx.clearRect(0, 0, canvas.width, canvas.height);
        analyser.getByteFrequencyData(dataArray);

        drawVisualiserRotation02(bufferLength, x, barWidth, barHeight, dataArray);

        requestAnimationFrame(animate);
    }
    animate();
};

// private voids

function drawVisualiserRotation02(bufferLength, x, barWidth, barHeight, dataArray) {

    for (let i = 0; i < bufferLength; i++) {
        barHeight = dataArray[i] * 1;

        // rotation
        ctx.save();
        ctx.translate(canvas.width/2, canvas.height/2);
        ctx.rotate(i * Math.PI * 3 / bufferLength);
        

        // HSL color: hue, saturation, lightness
        //            hsl(360, 100%, 50%)
        const hue = 330;
        ctx.fillStyle = 'hsl(' + hue + ',38%, 26%)';
        ctx.fillRect(0, 0, barWidth, barHeight);

        x += barWidth;

        ctx.restore();
    } 
};