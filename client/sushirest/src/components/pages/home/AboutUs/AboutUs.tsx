import style from "./aboutUs.module.scss"
import {AboutUsSlider} from "../../../../index.ts"
export const AboutUs = () => {
    return (
        <div className={style.wrapper}>
            <h1>about us</h1>
            <AboutUsSlider/>
        </div>
    );
}
