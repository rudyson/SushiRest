import style from "./menu.module.scss"
import {Categories, SearchAndFilters} from "../../index.ts";
const Menu = () => {
    return (
        <div className={style.wrapper}>
            <section className={style.textCategories}>
                <h1>Menu</h1>
                <Categories/>
            </section>
            <SearchAndFilters/>
        </div>
    )
}

export default Menu
