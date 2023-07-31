import style from "./topPosSlide.module.scss"
import topSushiBack from "../../../../../../pics/home/topPositions/topSushiBack.png";
import {Rating} from "../../../../../../index.ts";
export const TopPosSlide= ({...obj}) => {
    return (
        <>
            <div className={style.textDiv}>
                <section className={style.textPart}>
                    <h3>{obj.title}</h3>
                    <p className={style.piecesText}>{obj.pieces} pieces, {obj.weight} lb</p>
                    <p className={style.description}>{obj.description}</p>
                    <Rating/>
                </section>
                <section className={style.pricePart}>
                    <p>{obj.price}$</p>
                </section>
            </div>
            <div className={style.imgDiv}>
                <img className={style.imgBack} src={topSushiBack}></img>
            </div>
        </>
    )
}
