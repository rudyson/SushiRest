import style from "./topPositions.module.scss"
import {TopPositionSlider} from "../../../index.ts";
export const TopPositions = () => {
    return (
        <div className={style.wrapper}>
            <h1> <span>Top</span> positions sushi</h1>
            <p className={style.description}>The assortment of SushiRest presents roles, sushi,<br/>
                networks and drinks for any relish. We recommend<br/>
                you to try the top positions of our menu!</p>
            <TopPositionSlider/>
        </div>
    )
}
