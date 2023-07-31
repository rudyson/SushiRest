import style from "./feedbacks.module.scss"
import {FeedbacksSlider} from "../../../../index.ts";
export const Feedbacks= () => {
    return (
        <div className={style.wrapper}>
            <h1>FEEDBACKS</h1>
            <FeedbacksSlider/>
        </div>
    )
}
