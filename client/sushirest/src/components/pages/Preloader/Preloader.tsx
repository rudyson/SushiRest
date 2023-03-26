import { Player} from "@lottiefiles/react-lottie-player";
const Preloader = () => {
    return (
        <div>
            <Player
                autoplay
                loop
                src="https://assets5.lottiefiles.com/packages/lf20_fcwn3ayv.json"
                style={{ height: '100%', width: '100%' }}
            >
            </Player>
        </div>
    );
}

export default Preloader;