import style from "./AboutUs.module.css"
import AboutUsSlider from "./AboutUsSlider/AboutUsSlider";

const AboutUs = () => {
    return (
        <div className={style.wrapper}>
            <h1 className={style.text}>about us</h1>
            <AboutUsSlider/>
        </div>
    );
}

export default AboutUs;