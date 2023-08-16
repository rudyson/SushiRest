import style from "./feedbackSlide.module.scss"
import "../../../../../App.css"
import slideBack from "../../../../../pics/home/feedbacks/feedbackSlideBack.png"
import {Rating} from "../../../../../index.ts";
export const FeedbackSlide= () => {
    return (
        <div className={style.wrapper}>
            <section className={style.infoPart}>
                <img className={style.imgBack} src={slideBack}></img>
                <section>
                    <h3>Peter Marsh</h3>
                    <p>Regular customer</p>
                </section>
            </section>
            <section className={style.textAndRating}>
                <Rating/>
                <p>I really like sushi with a marine theme, from and I ordered perch and shrimp. Great time guaranteed.
                    The sushi itself is very rich and even sometimes it seems that they are not real to eat.
                    The freshness of the...</p>
            </section>
        </div>
    )
}
