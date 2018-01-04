package projectrider.bindingModel;

public class ProjectBindingModel {
	private String title;

	private String description;

	private Long budget;

    public ProjectBindingModel() {
    }

    public ProjectBindingModel(String title, String description, Long budget) {
        this.title = title;
        this.description = description;
        this.budget = budget;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public Long getBudget() {
        return budget;
    }

    public void setBudget(Long budget) {
        this.budget = budget;
    }
}
