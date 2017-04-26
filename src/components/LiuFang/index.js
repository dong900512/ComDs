import footbar from './footbar'
import loading from './loading'
import modal from './modal'
const components = [
    footbar,
    loading,
    modal
]
const install = (Vue, options = {}) => {
    components.map(component => {
        Vue.component(component.name, component)
    })
}
export default { install }