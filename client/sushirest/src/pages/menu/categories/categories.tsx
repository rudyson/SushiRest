import style from "./categories.module.scss"
import {useState} from "react";


const categories = ["Sets", "Rolls", "Wok", "Salads"]
export const Categories = () => {
    const [categoryId, setCategoryId] = useState(0)
    const onChangeCategory = (i) => {
        setCategoryId(i)
    }
    return (
        <ul className={style.wrapper}>
            {categories.map((el, i) => (
                <li
                    key={i}
                    onClick={() => onChangeCategory(i)}
                    className={categoryId === i ? style.activeChoice : ''}
                >{el}</li>
            ))}
        </ul>
    )
}
